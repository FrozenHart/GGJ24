using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Gameplay : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmationDialog;
    [SerializeField]
    private Slider Midle_Slider, Left_Slider, Right_Slider;
    [SerializeField]
    private GameObject Enemy_Mid, Enemy_Left, Enemy_Right;
    private Enemy enemy_mid, enemy_left, enemy_right;
    public object Midle_Slicder { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        confirmationDialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Midle_Slider.value = enemy_mid.Get_LaughPower();
        Left_Slider.value = enemy_left.Get_LaughPower();
        Right_Slider.value = enemy_right.Get_LaughPower();
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
    private void Level1()
    {
        int enemyid = new System.Random().Next(0, 12);
        enemy_mid = GameManager.enemies[enemyid];
    }
}
