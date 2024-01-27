using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4;
    private bool isLoaded = false;

    public void BasicCardShop_OnClick()
    {
        GameManager.currentShopType = ShopType.Basic;
        isLoaded = false;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void SpecialCardShop_OnClick()
    {
        GameManager.currentShopType = ShopType.Special;
        isLoaded = false;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void SuperCardShop_OnClick()
    {
        GameManager.currentShopType = ShopType.Super;
        isLoaded = false;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void GoBack_OnClick()
    {
        isLoaded = false;
        SceneManager.LoadSceneAsync("Gameplay");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.ResetShopType();
        LoopImages();
    }
    
    private async void LoopImages()
    {
        List<GameObject> images = new List<GameObject>() { ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4 };
        isLoaded = true;
        int count = 0;
        while (isLoaded && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Shop"))
        {
            images[count - 1 >= 0 ? count - 1 : 3].SetActive(false);
            images[count].SetActive(true);
            await Task.Delay(125);
            count++;
            if (count == 4) count = 0;
            
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
