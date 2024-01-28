using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject howtoplayDialog, creditDialog;

    public void Quit_OnClick()
    {
        Application.Quit();
    }

    public void StartGame_OnClick()
    {
        GameManager.StartNewGame();
        SceneManager.LoadScene("Shop"); 
    }

    public void ShowHowToPlay_OnClick()
    {
        howtoplayDialog.SetActive(true);
    }

    public void CloseHowToPlay_OnClick()
    {
        howtoplayDialog.SetActive(false);
    }

    public void ShowCredits_OnClick()
    {
        creditDialog.SetActive(true);
    }

    public void CloseCredits_OnClick()
    {
        creditDialog.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
