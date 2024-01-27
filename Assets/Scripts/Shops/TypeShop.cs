using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypeShop : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text shopType;
    private GameObject ShopLoop1, ShopLoop2, ShopLoop3, ShopLoop4;
    private bool isLoaded = false;

    // Start is called before the first frame update
    public void Start()
    {
        shopType.text = GameManager.currentShopType.ToString();
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

    public void GoBack_OnClick()
    {
        SceneManager.LoadSceneAsync("Shop");
    }
}
