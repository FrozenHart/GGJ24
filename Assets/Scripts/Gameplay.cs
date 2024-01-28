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
    public GameObject Midle_Slider, Left_Slider, Right_Slider;
    [SerializeField]
    private GameObject Enemy_Mid, Enemy_Left, Enemy_Right;
    private Enemy enemy_mid, enemy_left, enemy_right;
    public object Midle_Slicder { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        confirmationDialog.SetActive(false);
        Hide_All();
    }

    // Update is called once per frame
    void Update()
    {
      //  Midle_Slider.GetComponent<Slider>().value = enemy_mid.Get_LaughPower();
      //  Left_Slider.GetComponent<Slider>().value = enemy_left.Get_LaughPower();
       //  Right_Slider.GetComponent<Slider>().value = enemy_right.Get_LaughPower();
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
    private void Level_type_123()
    {
        int enemyid = new System.Random().Next(0, 12);
        enemy_mid = DefaultGameStorage.enemyList[enemyid];
    }
    private void Level_type_456()
    {
        int enemyid = new System.Random().Next(0, 12);
        enemy_mid = DefaultGameStorage.enemyList[enemyid];
    }
    private void Level_type_7()
    {
        int enemyid = new System.Random().Next(0, 12);
        enemy_mid = DefaultGameStorage.enemyList[enemyid];
    }
    private void Hide_All()
    {
       // Midle_Slider.SetActive(false);
       // Left_Slider.SetActive(false);
       // Right_Slider.SetActive(false);
       // Enemy_Mid.SetActive(false);
       // Enemy_Left.SetActive(false);
       // Enemy_Right.SetActive(false);
    }
}
