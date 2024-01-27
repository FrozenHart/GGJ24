using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public void BasicCardShop_OnClick()
    {
        ShopStorage.currentType = ShopStorage.ShopType.Basic;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void SpecialCardShop_OnClick()
    {
        ShopStorage.currentType = ShopStorage.ShopType.Special;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void SuperCardShop_OnClick()
    {
        ShopStorage.currentType = ShopStorage.ShopType.Super;
        SceneManager.LoadSceneAsync("TypeShop");
    }

    public void GoBack_OnClick()
    {
        ShopStorage.ResetType();
        SceneManager.LoadSceneAsync("Gameplay");
    }

    // Start is called before the first frame update
    void Start()
    {
        ShopStorage.ResetType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
