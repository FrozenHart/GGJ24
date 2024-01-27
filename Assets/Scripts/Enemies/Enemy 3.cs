using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3 : MonoBehaviour
{
    [SerializeField]
    private float boringness = 0.50f;
    private List<HumourType> Likes = new List<HumourType>() { HumourType.Dark, HumourType.x };
    private List<HumourType> DisLike = new List<HumourType>() { HumourType.Banana };
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

    public void SetSlider(Slider slider)
    {
        LaghBar = slider;
    }
}
