using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3 : MonoBehaviour
{
    [SerializeField]
    private float boringness = 0.50f;
    private List<HumourType> Likes = new List<HumourType>() { HumourType.Dark, HumourType.Intelligent };
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
    public void Action(Card card)
    {
        int LaughPower = card.GetLaughPower();
        foreach (HumourType card_humor in card.GetEffects())
        {
            if (Likes.Contains(card_humor))
            {
                LaughPower++;
            }
            else if (DisLike.Contains(card_humor))
            {
                LaughPower--;
            }
        }
        boringness += LaughPower;
    }
    public void SetSlider(Slider slider)
    {
        LaghBar = slider;
    }
}
