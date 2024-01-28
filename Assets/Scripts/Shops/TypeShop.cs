using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeShop : MonoBehaviour
{
    [SerializeField]
    private Button basicCard1, basicCard2, basicCard3, basicCard4, basicCard5, basicCard6, specialCard1, specialCard2, specialCard3, superCard;

    private List<Tuple<Button, HashSet<HumourType>>> basicButtons, specialButtons;
    private Tuple<Button, HashSet<HumourType>> superButton;

    [SerializeField]
    private TMPro.TMP_Text shopType, coinCount;

    [SerializeField]
    private GameObject ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4;
    private bool isLoaded = false;
    private int loopCount = GameManager.currentShopLoopFrame;

    private List<int> costs = new List<int>() { 20, 50, 200 };

    // Start is called before the first frame update
    public void Start()
    {
        shopType.text = GameManager.currentShopType.ToString() + " Card Shop";

        basicButtons = new List<Tuple<Button, HashSet<HumourType>>>() { 
            new Tuple<Button, HashSet<HumourType>>(basicCard1, DefaultGameStorage.AB),
            new Tuple<Button, HashSet<HumourType>>(basicCard2, DefaultGameStorage.AC),
            new Tuple<Button, HashSet<HumourType>>(basicCard3, DefaultGameStorage.AD),
            new Tuple<Button, HashSet<HumourType>>(basicCard4, DefaultGameStorage.BC),
            new Tuple<Button, HashSet<HumourType>>(basicCard5, DefaultGameStorage.BD),
            new Tuple<Button, HashSet<HumourType>>(basicCard6, DefaultGameStorage.CD)
        };

        specialButtons = new List<Tuple<Button, HashSet<HumourType>>>() {
            new Tuple<Button, HashSet<HumourType>>(specialCard1, DefaultGameStorage.ABC),
            new Tuple<Button, HashSet<HumourType>>(specialCard2, DefaultGameStorage.ABD),
            new Tuple<Button, HashSet<HumourType>>(specialCard3, DefaultGameStorage.ACD)
        };

        superButton = new Tuple<Button, HashSet<HumourType>>(superCard, DefaultGameStorage.super);

        SetupAvailableCards();
        coinCount.text = GameManager.player.GetMana().ToString();
        LoopImages();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    private async void LoopImages()
    {
        List<GameObject> images = new List<GameObject>() { ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4 };
        isLoaded = true;
        while (isLoaded && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TypeShop"))
        {
            if (images[loopCount] == null) return;
            images[loopCount - 1 >= 0 ? loopCount - 1 : 3].SetActive(false);
            images[loopCount].SetActive(true);
            await Task.Delay(125);
            loopCount++;
            if (loopCount == 4) loopCount = 0;
        }
    }

    public void GoBack_OnClick()
    {
        GameManager.currentShopLoopFrame = loopCount;
        SceneManager.LoadSceneAsync("Shop");
    }

    public void Card1_Click()
    {
        BuyCard(0);
    }

    public void Card2_Click()
    {
        BuyCard(1);
    }

    public void Card3_Click()
    {
        BuyCard(2);
    }

    public void Card4_Click()
    {
        BuyCard(3);
    }

    public void Card5_Click()
    {
        BuyCard(4);
    }

    public void Card6_Click()
    {
        BuyCard(5);
    }

    public void BuyCard(int num)
    {
        Player player = GameManager.player;
        List<Card> cards = GameManager.player.GetInventory();
        List<Card> allCards = DefaultGameStorage.GameCards;

        switch (GameManager.currentShopType)
        {
            case ShopType.Basic:
                if (num < 0 || num > 6)
                    break;
                player.SetMana(player.GetMana() - costs[0]);
                var newCard = allCards.Where(x => !cards.Contains(x) && canObtain(basicButtons[num].Item2));
                if (!newCard.Any())
                    break;
                player.AddCard(newCard.First());
                break;
            case ShopType.Special:
                if (num < 0 || num > 3)
                    break;
                player.SetMana(player.GetMana() - costs[1]);
                var newCard2 = allCards.Where(x => !cards.Contains(x) && canObtain(basicButtons[num].Item2));
                if (!newCard2.Any())
                    break;
                player.AddCard(newCard2.First());
                break;
            case ShopType.Super:
                if (num < 0 || num > 1)
                    break;
                player.SetMana(player.GetMana() - costs[2]);
                var newCard3 = allCards.Where(x => !cards.Contains(x) && canObtain(basicButtons[num].Item2));
                if (!newCard3.Any())
                    break;
                player.AddCard(newCard3.First());
                break;
        }
        
        coinCount.text = player.GetMana().ToString();

        ResetAll();
        SetupAvailableCards(); 
    }

    private void SetupAvailableCards()
    {
        List<HashSet<HumourType>> availableHumours = new List<HashSet<HumourType>>();

        Player player = GameManager.player;
        switch (GameManager.currentShopType)
        {
            case ShopType.Basic:
                foreach (var card in basicButtons)
                {
                    card.Item1.gameObject.SetActive(true);
                    card.Item1.interactable = player.GetMana() >= costs[0] && canObtain(card.Item2);
                }
                break;
            case ShopType.Special:
                foreach (var card in specialButtons)
                {
                    card.Item1.gameObject.SetActive(true);
                    card.Item1.interactable = player.GetMana() >= costs[1] && canObtain(card.Item2);
                }
                break;
            case ShopType.Super:
                superCard.gameObject.SetActive(true);
                superCard.interactable = player.GetMana() >= costs[2] && canObtain(superButton.Item2);
                break;
        }
    }

    private bool canObtain(HashSet<HumourType> cardType)
    {
        List<Card> cards = GameManager.player.GetInventory();

        ~//if (cards.Select(x => x.GetEffects().ElementAt(0) == cardType.ElementAt(0) && x.GetEffects().ElementAt(1) == cardType.ElementAt(1)).Count() == 2)
            //return false;

        return true;
    }

    private void ResetAll()
    {
        foreach (var card in basicButtons)
        {
            card.Item1.gameObject.SetActive(false);
        }

        foreach (var card in specialButtons)
        {
            card.Item1.gameObject.SetActive(false);
        }

        superCard.gameObject.SetActive(false);
    }
}
