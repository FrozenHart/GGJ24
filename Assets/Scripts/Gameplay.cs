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
    private GameObject Midle_Slider, Left_Slider, Right_Slider;
    [SerializeField]
    private GameObject Enemy_Mid, Enemy_Left, Enemy_Right;
    public Animator Enemy_Mid_Animator, Enemy_Left_Animator, Enemy_Right_Animator;
    private Enemy enemy_mid, enemy_left, enemy_right;
    private bool Level1=false, Level2=false, Level3=false;
    public object Midle_Slicder { get; private set; }
    bool trade = false;

    // Start is called before the first frame update
    void Start()
    {
        confirmationDialog.SetActive(false);
        Level_type_123();
    }
    private void FixedUpdate()
    {
        if (Level1)
        {
            Midle_Slider.GetComponent<Slider>().value = enemy_mid.Get_LaughPower();
            Enemy_Mid_Animator.SetFloat("laughpower", enemy_mid.Get_LaughPower());
        }
        else if (Level2)
        {
            Left_Slider.GetComponent<Slider>().value = enemy_left.Get_LaughPower();
            Enemy_Left_Animator.SetFloat("laughpower", enemy_left.Get_LaughPower());
            Right_Slider.GetComponent<Slider>().value = enemy_right.Get_LaughPower();
            Enemy_Right_Animator.SetFloat("laughpower", enemy_right.Get_LaughPower());
        }
        else if (Level3)
        {
            Left_Slider.GetComponent<Slider>().value = enemy_left.Get_LaughPower();
            Enemy_Left_Animator.SetFloat("laughpower", enemy_left.Get_LaughPower());
            Right_Slider.GetComponent<Slider>().value = enemy_right.Get_LaughPower();
            Enemy_Right_Animator.SetFloat("laughpower", enemy_right.Get_LaughPower());
            Midle_Slider.GetComponent<Slider>().value = enemy_mid.Get_LaughPower();
            Enemy_Mid_Animator.SetFloat("laughpower", enemy_mid.Get_LaughPower());
        }
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
    private void Level_type_123()
    {
        Hide_All();
        int enemyidm = new System.Random().Next(0, 12);
        enemy_mid = DefaultGameStorage.enemyList[enemyidm];
        Level1 = true;
        Level2 = false;
        Level3 = false;
        Midle_Slider.SetActive(true);
        Enemy_Mid.SetActive(true);
    }
    private void Level_type_456()
    {
        Hide_All();
        int enemyidl = new System.Random().Next(0, 12);
        int enemyidr = new System.Random().Next(0, 12);
        enemy_left = DefaultGameStorage.enemyList[enemyidl];
        enemy_right = DefaultGameStorage.enemyList[enemyidr];
        Level2 = true;
        Level1 = false;
        Level3 = false;
        Left_Slider.SetActive(true);
        Right_Slider.SetActive(true);
        Enemy_Left.SetActive(true);
        Enemy_Right.SetActive(true);
    }
    private void Level_type_7()
    {
        Hide_All();
        int enemyidm = new System.Random().Next(0, 12);
        int enemyidl = new System.Random().Next(0, 12);
        int enemyidr = new System.Random().Next(0, 12);
        enemy_mid = DefaultGameStorage.enemyList[enemyidm];
        enemy_left = DefaultGameStorage.enemyList[enemyidl];
        enemy_right = DefaultGameStorage.enemyList[enemyidr];
        Level3 = true;
        Level2 = false;
        Level1 = false;
        Left_Slider.SetActive(true);
        Right_Slider.SetActive(true);
        Enemy_Left.SetActive(true);
        Enemy_Right.SetActive(true);
        Midle_Slider.SetActive(true);
        Enemy_Mid.SetActive(true);
    }
    private void Hide_All()
    {
        Midle_Slider.SetActive(false);
        Left_Slider.SetActive(false);
        Right_Slider.SetActive(false);
        Enemy_Mid.SetActive(false);
        Enemy_Left.SetActive(false);
        Enemy_Right.SetActive(false);
    }
}
