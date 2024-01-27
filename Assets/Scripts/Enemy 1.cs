using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] private int boringness = 100; // aka life
    private List<Effects> Likes = new List<Effects>() {Effects.Banana,Effects.y };
    private List<Effects> Dislikes = new List<Effects>() {Effects.Inteligente};
    [SerializeField] private Slider Laght;
    // Start is called before the first frame update
    void Start()
    {
        Laght.value = boringness;
    }

    // Update is called once per frame
    void Update()
    {
        Laght.value = boringness;
    }

    public void Take_Damage(List<Effects> cardefects, int damage)
    {

    }

}
