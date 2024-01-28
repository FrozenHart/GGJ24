using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4, InvalidDialog;
    [SerializeField]
    private TMPro.TMP_Text coinCount;

    private bool isLoaded = false;
    private int loopCount = GameManager.currentShopLoopFrame;

    public void BasicCardShop_OnClick()
    {
        isLoaded = false;
        GameManager.currentShopLoopFrame = loopCount;
        GameManager.currentShopType = ShopType.Basic;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void SpecialCardShop_OnClick()
    {
        isLoaded = false;
        GameManager.currentShopLoopFrame = loopCount;
        GameManager.currentShopType = ShopType.Special;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void SuperCardShop_OnClick()
    {
        isLoaded = false;
        GameManager.currentShopLoopFrame = loopCount;
        GameManager.currentShopType = ShopType.Super;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void GoBack_OnClick()
    {
        if (GameManager.player.GetInventory().Count < 5)
        {
            InvalidDialog.SetActive(true);
            return;
        }

        if (GameManager.Level >= 3 && GameManager.player.GetInventory().Count < 7)
        {
            InvalidDialog.SetActive(true);
            return;
        }

        if (GameManager.Level >= 5 && GameManager.player.GetInventory().Count < 10)
        {
            InvalidDialog.SetActive(true);
            return;
        }

        isLoaded = false;
        GameManager.currentShopLoopFrame = 0;
        SceneManager.LoadSceneAsync("Gameplay");
    }

    public void CloseDialog_OnClick()
    {
        InvalidDialog.SetActive(false);
    }

    public void GetMoney_Click()
    {
        GameManager.player.SetMana(GameManager.player.GetMana() + 10);
        coinCount.text = GameManager.player.GetMana().ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.ResetShopType();
        coinCount.text = GameManager.player.GetMana().ToString();
        LoopImages();
    }
    
    private async void LoopImages()
    {
        List<GameObject> images = new List<GameObject>() { ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4 };
        isLoaded = true;
        while (isLoaded && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Shop"))
        {
            images[loopCount - 1 >= 0 ? loopCount - 1 : 3].SetActive(false);
            images[loopCount].SetActive(true);
            await Task.Delay(125);
            loopCount++;
            if (loopCount == 4) loopCount = 0; 
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
