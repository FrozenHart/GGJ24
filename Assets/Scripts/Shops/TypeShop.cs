using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeShop : MonoBehaviour
{
    [SerializeField] 
    private Button card1B, card2B, card3B;

    [SerializeField]
    private GameObject card1Coin, card2Coin, card3Coin;

    [SerializeField]
    private TMPro.TMP_Text shopType, coinCount;

    [SerializeField]
    private TMPro.TMP_Text card1Title, card1Description, card1Cost;

    [SerializeField]
    private TMPro.TMP_Text card2Title, card2Description, card2Cost;

    [SerializeField]
    private TMPro.TMP_Text card3Title, card3Description, card3Cost;

    [SerializeField]
    private GameObject ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4;
    private bool isLoaded = false;
    private int loopCount = GameManager.currentShopLoopFrame;

    private List<Card> cards = new List<Card>();

    // Start is called before the first frame update
    public void Start()
    {
        shopType.text = GameManager.currentShopType.ToString() + " Card Shop";
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

        player.SetMana(player.GetMana() - cards[num].GetManaCost());
        player.AddCard(cards[num]);
        cards.RemoveAt(num);

        ResetAll();
        SetupAvailableCards(false);
        card1B.interactable = cards.Count > 0 ? player.GetMana() >= cards[0].GetManaCost() : false;
        card2B.interactable = cards.Count > 1 ? player.GetMana() >= cards[1].GetManaCost() : false;
        card3B.interactable = cards.Count > 2 ? player.GetMana() >= cards[2].GetManaCost() : false;  
    }

    private void SetupAvailableCards(bool renew = true)
    {
        if (renew)
            cards = GameManager.GetCards(GameManager.currentShopType);

        if (cards.Count < 1) return;

        card1B.interactable = GameManager.player.GetMana() >= cards[0].GetManaCost();
        card1B.gameObject.SetActive(true);
        card1Title.text = cards[0].GetName();
        card1Description.text = cards[0].GetDescription();
        card1Cost.text = cards[0].GetManaCost().ToString();
        card1Cost.color = GameManager.player.GetMana() >= cards[0].GetManaCost() ? Color.black: Color.red;
        card1Cost.gameObject.SetActive(true);
        card1Coin.SetActive(true);

        if (cards.Count < 2) return;

        card2B.interactable = GameManager.player.GetMana() >= cards[1].GetManaCost();
        card2B.gameObject.SetActive(true);
        card2Title.text = cards[1].GetName();
        card2Description.text = cards[1].GetDescription();
        card2Cost.text = cards[1].GetManaCost().ToString();
        card2Cost.color = GameManager.player.GetMana() >= cards[1].GetManaCost() ? Color.black : Color.red;
        card2Cost.gameObject.SetActive(true);
        card2Coin.SetActive(true);

        if (cards.Count < 3) return;

        card3B.interactable = GameManager.player.GetMana() >= cards[2].GetManaCost();
        card3B.gameObject.SetActive(true);
        card3Title.text = cards[2].GetName();
        card3Description.text = cards[2].GetDescription();
        card3Cost.text = cards[2].GetManaCost().ToString();
        card3Cost.color = GameManager.player.GetMana() >= cards[2].GetManaCost() ? Color.black : Color.red;
        card3Cost.gameObject.SetActive(true);
        card3Coin.SetActive(true);
    }

    private void ResetAll()
    {
        card1B.interactable = false;
        card1B.gameObject.SetActive(true);
        card1Title.text = "";
        card1Description.text = "Not Available";
        card1Cost.text = "";
        card1Cost.gameObject.SetActive(false);
        card1Coin.SetActive(false);

        card2B.interactable = false;
        card2B.gameObject.SetActive(true);
        card2Title.text = "";
        card2Description.text = "Not Available";
        card2Cost.text = "";
        card2Cost.gameObject.SetActive(false);
        card2Coin.SetActive(false);

        card3B.interactable = false;
        card3B.gameObject.SetActive(true);
        card3Title.text = "";
        card3Description.text = "Not Available";
        card3Cost.text = "";
        card3Cost.gameObject.SetActive(false);
        card3Coin.SetActive(false);
    }
}
