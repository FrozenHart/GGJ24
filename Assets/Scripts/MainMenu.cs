using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Quit_OnClick()
    {
        Application.Quit();
    }

    public void StartGame_OnClick()
    {
        SceneManager.LoadSceneAsync("Gameplay");
        GameManager.StartNewGame();
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
