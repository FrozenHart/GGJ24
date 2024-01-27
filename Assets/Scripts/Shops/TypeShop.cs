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

    // Start is called before the first frame update
    public void Start()
    {
        shopType.text = GameManager.currentShopType.ToString() + " Card Shop";
        SetupAvailableCards();
        coinCount.text = GameManager.player.GetMana().ToString();
        LoopImages();
    }

    private void SetupAvailableCards()
    {
        List<Card> cards = GameManager.GetCards(GameManager.currentShopType);

        if (cards.Count < 1) return;

        card1B.interactable = true;
        card1B.gameObject.SetActive(true);
        card1Title.text = cards[0].GetName();
        card1Description.text = cards[0].GetDescription();
        card1Cost.text = cards[0].GetManaCost().ToString();
        card1Cost.gameObject.SetActive(true);
        card1Coin.SetActive(true);

        if (cards.Count < 2) return;

        card2B.interactable = true;
        card2B.gameObject.SetActive(true);
        card2Title.text = cards[1].GetName();
        card2Description.text = cards[1].GetDescription();
        card2Cost.text = cards[1].GetManaCost().ToString();
        card2Cost.gameObject.SetActive(true);
        card2Coin.SetActive(true);

        if (cards.Count < 3) return;

        card3B.interactable = true;
        card3B.gameObject.SetActive(true);
        card3Title.text = cards[2].GetName();
        card3Description.text = cards[2].GetDescription();
        card3Cost.text = cards[2].GetManaCost().ToString();
        card3Cost.gameObject.SetActive(true);
        card3Coin.SetActive(true);
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
}
