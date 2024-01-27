using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class States : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu, Level1, Level2, Level3, Level4, Level5, Level6, Level7, Inventory, Shop, LBleft, LBright, LBmid, LBcanvas;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Level_1()
    {

    }

    public void Level_2()
    {

    }

    public void Level_3()
    {

    }

    public void Level_4()
    {

    }

    public void Level_5()
    {

    }

    public void Level_6()
    {

    }

    public void Level_7()
    {

    }

    public void Shop_OnClick()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

}
