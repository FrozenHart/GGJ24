using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeShop : MonoBehaviour
{
    [SerializeField]
    private Button basicCard1, basicCard2, basicCard3, basicCard4, basicCard5, basicCard6, specialCard1, specialCard2, specialCard3, superCard;

    private List<Button> basicButtons, specialButtons;

    [SerializeField]
    private TMPro.TMP_Text shopType, coinCount;

    [SerializeField]
    private GameObject ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4;
    private bool isLoaded = false;
    private int loopCount = GameManager.currentShopLoopFrame;

    private List<HashSet<HumourType>> newHumour = new List<HashSet<HumourType>>();
    private List<int> costs = new List<int>() { 20, 50, 200 };

    // Start is called before the first frame update
    public void Start()
    {
        shopType.text = GameManager.currentShopType.ToString() + " Card Shop";

        basicButtons = new List<Button>() { basicCard1, basicCard2, basicCard3, basicCard4, basicCard5, basicCard6 };
        specialButtons = new List<Button>() { specialCard1, specialCard2, specialCard3 };

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

    public void BuyCard(int num)
    {
        if (num < 0 || num > 2) return;

        Player player = GameManager.player;

        player.SetMana(player.GetMana() - costs[num]);
        coinCount.text = player.GetMana().ToString();

        ResetAll();
        SetupAvailableCards(false);


        int count = 0;
        foreach (Button button in basicButtons)
        {
            button.interactable = player.GetMana() >= costs[count];
        } 
    }

    private void SetupAvailableCards(bool renew = true)
    {
        List<HashSet<HumourType>> availableHumours = new List<HashSet<HumourType>>();

        Player player = GameManager.player;
        switch (GameManager.currentShopType)
        {
            case ShopType.Basic:
                foreach (var card in basicButtons)
                {
                    card.gameObject.SetActive(true);
                    card.interactable = player.GetMana() >= costs[0];
                }
                break;
            case ShopType.Special:
                foreach (var card in specialButtons)
                {
                    card.gameObject.SetActive(true);
                    card.interactable = player.GetMana() >= costs[1];
                }
                break;
            case ShopType.Super:
                superCard.gameObject.SetActive(true);
                superCard.interactable = player.GetMana() >= costs[2];
                break;
        }
    }

    private void ResetAll()
    {
        foreach (var card in basicButtons)
        {
            card.gameObject.SetActive(false);
        }

        foreach (var card in specialButtons)
        {
            card.gameObject.SetActive(false);
        }

        superCard.gameObject.SetActive(false);
    }
}
