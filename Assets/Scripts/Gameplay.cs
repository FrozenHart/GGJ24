using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmationDialog;

    // Start is called before the first frame update
    void Start()
    {
        confirmationDialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shop_OnClick()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

    public void MainMenu_OnClick()
    {
        confirmationDialog.SetActive(true); 
    }

    public void MenuConfirmDialog_Yes_OnClick()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void MenuConfirmDialog_No_OnClick()
    {
        confirmationDialog.SetActive(false);
    }
}
