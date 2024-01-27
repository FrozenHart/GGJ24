using UnityEngine;
using UnityEngine.SceneManagement;

public class TypeShop : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text shopType;

    // Start is called before the first frame update
    public void Start()
    {
        shopType.text = ShopStorage.currentType.ToString();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void GoBack_OnClick()
    {
        SceneManager.LoadSceneAsync("Shop");
    }
}
