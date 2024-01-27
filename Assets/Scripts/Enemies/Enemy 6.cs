using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy6 : MonoBehaviour
{
    [SerializeField]
    private float boringness = 0.50f;
    private List<HumourType> Likes = new List<HumourType>() { HumourType.Dark, HumourType.y };
    private List<HumourType> DisLike = new List<HumourType>() { HumourType.Intelligent };
    public Slider LaghBar;

    // Start is called before the first frame update
    void Start()
    {
        LaghBar.value = boringness;
    }

    // Update is called once per frame
    void Update()
    { 
        LaghBar.value = boringness;
    }
    public void Action(Card carta)
    {

    }

    public void SetSlider(Slider slider)
    {
        LaghBar = slider;
    }

}