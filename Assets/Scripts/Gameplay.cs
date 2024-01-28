using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using TMPro;

public class Gameplay : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmationDialog;
    [SerializeField]
    private GameObject Midle_Slider, Left_Slider, Right_Slider, CardSpot_1,CardSpot_2,CardSpot_3,CardSpot_12,CardSpot_23,stats1,stats2,stats3,Levelnumb,CoinCount;
    [SerializeField]
    private GameObject Enemy_Mid, Enemy_Left, Enemy_Right;
    public Animator Enemy_Mid_Animator, Enemy_Left_Animator, Enemy_Right_Animator;
    private Enemy enemy_mid, enemy_left, enemy_right;
    private Card card1, card2, card3;
    private bool Level1 = false, Level2 = false, Level3 = false;
    private int Current_Level = 0;
    public object Midle_Slicder { get; private set; }
    private bool Pass = false;
    private int index = 0;
    public bool allhappy;
    private Sprite A= Resources.Load<Sprite>("Sprites/icons/A"), B = Resources.Load<Sprite>("Sprites/icons/B"), C = Resources.Load<Sprite>("Sprites/icons/C"), D = Resources.Load<Sprite>("Sprites/icons/D");

    // Start is called before the first frame update
    void Start()
    {
        confirmationDialog.SetActive(false);
        Pass = false;
        allhappy = false;
        GameManager.player.AddCard(DefaultGameStorage.GameCards[0]);
        GameManager.player.AddCard(DefaultGameStorage.GameCards[1]);
        GameManager.player.AddCard(DefaultGameStorage.GameCards[2]);
        GameManager.player.AddCard(DefaultGameStorage.GameCards[4]);
        GameManager.player.AddCard(DefaultGameStorage.GameCards[5]);
        NexLevel();
        Get_Inicial_Cards();
        Set_Cards();
        Set_Hand();
        CoinCount.GetComponent<TMPro.TMP_Text>().text = GameManager.player.GetMana().ToString();
    }
    private void FixedUpdate()
    {
        if (waitForConfirm) return;
        CheckAllHappy();
        if ((GameManager.player.GetHand().Count==0) || allhappy)
        {
            if(Level1)
            {
                if(enemy_mid.Get_LaughPower() >= 0.75f)
                {
                    Pass = true;
                }
            }
            else if (Level2)
            {
                if ((enemy_right.Get_LaughPower() >= 0.75f) && (enemy_left.Get_LaughPower() >= 0.75f))
                {
                    Pass = true;
                }
            }
            else if (Level3)
            {
                if ((enemy_mid.Get_LaughPower() >= 0.75f) && (enemy_right.Get_LaughPower() >= 0.75f) && (enemy_left.Get_LaughPower() >= 0.75f))
                {
                    Pass = true;
                }
            }
            if(Pass) { GameManager.Nexlev(); }
            SceneManager.LoadScene("Shop");
        }
        else
        {
            if (Level1)
            {
                Midle_Slider.GetComponent<Slider>().value = enemy_mid.Get_LaughPower();
                Enemy_Mid_Animator.SetFloat("laughpower", enemy_mid.Get_LaughPower());
            }
            else if (Level2)
            {
                Left_Slider.GetComponent<Slider>().value = enemy_left.Get_LaughPower();
                Enemy_Left_Animator.SetFloat("laughpower", enemy_left.Get_LaughPower());
                Right_Slider.GetComponent<Slider>().value = enemy_right.Get_LaughPower();
                Enemy_Right_Animator.SetFloat("laughpower", enemy_right.Get_LaughPower());
            }
            else if (Level3)
            {
                Left_Slider.GetComponent<Slider>().value = enemy_left.Get_LaughPower();
                Enemy_Left_Animator.SetFloat("laughpower", enemy_left.Get_LaughPower());
                Right_Slider.GetComponent<Slider>().value = enemy_right.Get_LaughPower();
                Enemy_Right_Animator.SetFloat("laughpower", enemy_right.Get_LaughPower());
                Midle_Slider.GetComponent<Slider>().value = enemy_mid.Get_LaughPower();
                Enemy_Mid_Animator.SetFloat("laughpower", enemy_mid.Get_LaughPower());
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void Shop_OnClick()
    {
        SceneManager.LoadSceneAsync("Shop");
    }
     
    public void MainMenu_OnClick()
    {
        confirmationDialog.SetActive(true); 
    }

    public void MenuConfirmDialog_Yes_OnClick()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void MenuConfirmDialog_No_OnClick()
    {
        confirmationDialog.SetActive(false);
    }
    private void Level_type_123()
    {
        Hide_All();
        int enemyidm = new System.Random().Next(0, 12);
        enemy_mid = DefaultGameStorage.enemyList[enemyidm];
        Level1 = true;
        Level2 = false;
        Level3 = false;
        Midle_Slider.SetActive(true);
        Enemy_Mid.SetActive(true);
    }
    private void Level_type_456()
    {
        Hide_All();
        int enemyidl = new System.Random().Next(0, 12);
        int enemyidr = new System.Random().Next(0, 12);
        enemy_left = DefaultGameStorage.enemyList[enemyidl];
        enemy_right = DefaultGameStorage.enemyList[enemyidr];
        Level2 = true;
        Level1 = false;
        Level3 = false;
        Left_Slider.SetActive(true);
        Right_Slider.SetActive(true);
        Enemy_Left.SetActive(true);
        Enemy_Right.SetActive(true);
    }
    private void Level_type_7()
    {
        Hide_All();
        int enemyidm = new System.Random().Next(0, 12);
        int enemyidl = new System.Random().Next(0, 12);
        int enemyidr = new System.Random().Next(0, 12);
        enemy_mid = DefaultGameStorage.enemyList[enemyidm];
        enemy_left = DefaultGameStorage.enemyList[enemyidl];
        enemy_right = DefaultGameStorage.enemyList[enemyidr];
        Level3 = true;
        Level2 = false;
        Level1 = false;
        Left_Slider.SetActive(true);
        Right_Slider.SetActive(true);
        Enemy_Left.SetActive(true);
        Enemy_Right.SetActive(true);
        Midle_Slider.SetActive(true);
        Enemy_Mid.SetActive(true);
    }
    private void Hide_All()
    {
        Midle_Slider.SetActive(false);
        Left_Slider.SetActive(false);
        Right_Slider.SetActive(false);
        Enemy_Mid.SetActive(false);
        Enemy_Left.SetActive(false);
        Enemy_Right.SetActive(false);
    }

    private void NexLevel()
    {
        switch (GameManager.Level)
        {
            case 1:
                if(Current_Level == GameManager.Level)
                {
                    enemy_mid.reset();
                }
                else
                {
                    Level_type_123();
                }
                Current_Level = GameManager.Level;
                Levelnumb.GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("Sprites/1") ;
                break;
            case 2:
                if (Current_Level == GameManager.Level)
                {
                    enemy_mid.reset();
                }
                else
                {
                    Level_type_123();
                }
                Current_Level = GameManager.Level;
                Levelnumb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/2");

                break;
            case 3:
                if (Current_Level == GameManager.Level)
                {
                    enemy_mid.reset();
                }
                else
                {
                    Level_type_123();
                }
                Current_Level = GameManager.Level;
                Levelnumb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/3");
                break;
            case 4:
                if (Current_Level == GameManager.Level)
                {
                    enemy_left.reset();
                    enemy_right.reset();
                }
                else
                {
                    Level_type_456();
                }
                Current_Level = GameManager.Level;
                Levelnumb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/4");

                break;
            case 5:
                if (Current_Level == GameManager.Level)
                {
                    enemy_left.reset();
                    enemy_right.reset();
                }
                else
                {
                    Level_type_456(); 
                }
                Current_Level = GameManager.Level;
                Levelnumb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/5");

                break;
            case 6:
                if (Current_Level == GameManager.Level)
                {
                    enemy_left.reset();
                    enemy_right.reset();
                }
                else
                {
                    Level_type_456();
                }
                Current_Level = GameManager.Level;
                Levelnumb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/6");

                break;
            case 7:
                if (Current_Level == GameManager.Level)
                {
                    enemy_left.reset();
                    enemy_right.reset();
                    enemy_mid.reset();
                }
                else 
                {
                    Level_type_7();
                }
                Current_Level = GameManager.Level;
                Levelnumb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/7");
                break;
        }
    }

    public void Select_Card_1()
    {
        ShowCard(card1);
        if (GameManager.player.GetHand().Count == 1)
        {
            GameManager.player.Reset_Hand();
        }
        else
        {
            GameManager.player.RemoveCardFromHand(card1);
        }
        index--;
        if(Level1)
        {
            enemy_mid.Action(card1);
        }
        else if(Level2)
        {
            enemy_left.Action(card1);
            enemy_right.Action(card1);
        }
        else
        {
            enemy_mid.Action(card1);
            enemy_left.Action(card1);
            enemy_right.Action(card1);
        }
        Set_Cards();
    }
    public void Select_Card_2()
    {
        ShowCard(card2);
        if (GameManager.player.GetHand().Count == 1)
        {
            GameManager.player.Reset_Hand();
        }
        else
        {
            GameManager.player.RemoveCardFromHand(card2);
        }
        index--;
        if (Level1)
        {
            enemy_mid.Action(card2);
        }
        else if (Level2)
        {
            enemy_left.Action(card2);
            enemy_right.Action(card2);
        }
        else
        {
            enemy_mid.Action(card2);
            enemy_left.Action(card2);
            enemy_right.Action(card2);
        }
        Set_Cards();
    }
    public void Select_Card_3()
    {
        ShowCard(card3);
        if (GameManager.player.GetHand().Count == 1)
        {
            GameManager.player.Reset_Hand();
        }
        else
        {
            GameManager.player.RemoveCardFromHand(card3);
        }
        index--;
        if (Level1)
        {
            enemy_mid.Action(card3);
        }
        else if (Level2)
        {
            enemy_left.Action(card3);
            enemy_right.Action(card3);
        }
        else
        {
            enemy_mid.Action(card3);
            enemy_left.Action(card3);
            enemy_right.Action(card3);
        }
        Set_Cards();
    }

    public void Select_Card_12() 
    {
        ShowCard(card1);
        if (GameManager.player.GetHand().Count == 1)
        {
            GameManager.player.Reset_Hand();
        }
        else
        {
            GameManager.player.RemoveCardFromHand(card1);
        }
        index--;
        if (Level1)
        {
            enemy_mid.Action(card1);
        }
        else if (Level2)
        {
            enemy_left.Action(card1);
            enemy_right.Action(card1);
        }
        else
        {
            enemy_mid.Action(card1);
            enemy_left.Action(card1);
            enemy_right.Action(card1);
        }
        Set_Cards();
    }
    public void Select_Card_23() {
        ShowCard(card2);
        if (GameManager.player.GetHand().Count == 1)
        {
            GameManager.player.Reset_Hand();
        }
        else { 
            GameManager.player.RemoveCardFromHand(card2); 
        }
        
        index--;
        if (Level1)
        {
            enemy_mid.Action(card2);
        }
        else if (Level2)
        {
            enemy_left.Action(card2);
            enemy_right.Action(card2);
        }
        else
        { 
            enemy_mid.Action(card2);
            enemy_left.Action(card2);
            enemy_right.Action(card2);
        }
        Set_Cards();
    }

    public void Rotate_right()
    {
        if (GameManager.player.GetHand().Count != 2)
        {
        
            card3 = card2;
            card2 = card1;
            if (index + 1 > GameManager.player.GetHand().Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            card1 = GameManager.player.GetHand()[index];
        }
    }

    public void Rotate_left() 
    {
        if (GameManager.player.GetHand().Count != 2)
        {
            card1 = card2;
            card2 = card3;
            if (index - 1 > 0)
            {
                index--;
            }
            else
            {
                index = GameManager.player.GetHand().Count - 1;
            }
            card3 = GameManager.player.GetHand()[index];
        }
    }

    public void Set_Hand()
    {
        Player player = GameManager.player;
        card1 = player.GetHand()[0];
        card2 = player.GetHand()[1];
        card3 = player.GetHand()[2];
        index = 2;
    }

    private void Set_Cards()
    {
        int numb_of_cards = GameManager.player.GetHand().Count;
        if(numb_of_cards==2)
        {
            Hide_Cards();
            CardSpot_12.SetActive(true);
            CardSpot_23.SetActive(true);
        }
        else if(numb_of_cards == 1)
        {
            Hide_Cards();
            CardSpot_2.SetActive(true);
        }
        else if(GameManager.player.GetHand().Any<Card>())
        {
            Hide_Cards();
            CardSpot_1.SetActive(true);
            CardSpot_2.SetActive(true);
            CardSpot_3.SetActive(true);
        }   
    }

    private void Hide_Cards()
    {
        CardSpot_1.SetActive(false);
        CardSpot_2.SetActive(false);
        CardSpot_3.SetActive(false);
        CardSpot_12.SetActive(false);
        CardSpot_23.SetActive(false);
        stats1.SetActive(false);
        stats2.SetActive(false);
        stats3.SetActive(false);
    }

    private void CheckAllHappy()
    {
        if(Level1)
        {
            if (enemy_mid.Get_LaughPower()==1f)
            {
                allhappy= true;
            }
        }
        else if(Level2) 
        {
            if((enemy_right.Get_LaughPower() == 1f) && (enemy_left.Get_LaughPower() >= 1f))
            {
                allhappy= true;
            }
        }
        else if (Level3)
        {
            if ((enemy_right.Get_LaughPower() == 1f) && (enemy_left.Get_LaughPower() >= 1f) && (enemy_mid.Get_LaughPower() == 1f))
            {
                allhappy = true;
            }
        }
    }
    private void Get_Inicial_Cards()
    {
        if(Level1)
        {
            for(int x=0;x<5;x++)
            {
                int indexcard = new System.Random().Next(0, GameManager.player.GetInventory().Count);
                foreach(Card item in DefaultGameStorage.GameCards)
                {
                    if(GameManager.player.GetInventory()[indexcard]==item)
                    {
                        GameManager.player.AddCard_ToHand(item);
                        Debug.Log("adicionou carta");
                    }
                }
            }
        }
        else if(Level2)//5
        {
            for (int x = 0; x < 7; x++)
            {
                int indexcard = new System.Random().Next(0, GameManager.player.GetInventory().Count);
                GameManager.player.AddCard_ToHand(GameManager.player.GetInventory()[indexcard]);
            }
        }
        else if(Level3)//7
        {
            for (int x = 0; x < 10; x++)
            {
                int indexcard = new System.Random().Next(0, GameManager.player.GetInventory().Count);
                GameManager.player.AddCard_ToHand(GameManager.player.GetInventory()[indexcard]);
            }
        }
    }

    [SerializeField]
    private GameObject cardName, cardDescription, cardDialog;
    bool waitForConfirm = false;

    private void ShowCard(Card card)
    {
        cardName.GetComponent<TMPro.TMP_Text>().text = card.GetName();
        cardDescription.GetComponent<TMPro.TMP_Text>().text = card.GetDescription();
        cardDialog.SetActive(true);
        waitForConfirm = true;
    }

    public void CloseCardDialog_OnClick()
    {
        cardDialog.SetActive(false);
        waitForConfirm = false;
    }
}
