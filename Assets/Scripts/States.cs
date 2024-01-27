using UnityEngine;
using UnityEngine.SceneManagement;

public class States : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu, Level1, Level2, Level3, Level4, Level5, Level6, Level7, Inventory, Shop;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Hide()
    {
        MainMenu.SetActive(false);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Level4.SetActive(false);
        Level5.SetActive(false);
        Level6.SetActive(false);
        Level7.SetActive(false);
        Inventory.SetActive(false);
        Shop.SetActive(false);
    }

    public void Level_1()
    {
        Hide();
        Level1.SetActive(true);
    }

    public void Level_2()
    {
        Hide();
        Level2.SetActive(true);

    }

    public void Level_3()
    {
        Hide();
        Level3.SetActive(true);

    }

    public void Level_4()
    {
        Hide();
        Level4.SetActive(true);

    }

    public void Level_5()
    {
        Hide();
        Level5.SetActive(true);

    }

    public void Level_6()
    {
        Hide();
        Level6.SetActive(true);

    }

    public void Level_7()
    {
        Hide();
        Level7.SetActive(true);

    }

    public void Shop_OnClick()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

}
