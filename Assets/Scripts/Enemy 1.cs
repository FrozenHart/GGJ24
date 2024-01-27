using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    [SerializeField]
    private float boringness = 0.50f;
    public Slider LaghBar;

    private List<Effects> Likes = new List<Effects>() { Effects.Banana,Effects.y};
    private List<Effects> DisLike = new List<Effects>() { Effects.Inteligente };


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
