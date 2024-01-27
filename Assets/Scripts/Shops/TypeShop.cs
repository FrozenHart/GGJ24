using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypeShop : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text shopType, coinCount;
    [SerializeField]
    private GameObject ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4;
    private bool isLoaded = false;
    private int loopCount = GameManager.currentShopLoopFrame;

    // Start is called before the first frame update
    public void Start()
    {
        shopType.text = GameManager.currentShopType.ToString();
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
