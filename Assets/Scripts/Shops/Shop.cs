using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public void BasicCardShop_OnClick()
    {
        GameManager.currentShopType = ShopType.Basic;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void SpecialCardShop_OnClick()
    {
        GameManager.currentShopType = ShopType.Special;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void SuperCardShop_OnClick()
    {
        GameManager.currentShopType = ShopType.Super;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void GoBack_OnClick()
    {
        GameManager.ResetShopType();
        SceneManager.LoadSceneAsync("Gameplay");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.ResetShopType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
