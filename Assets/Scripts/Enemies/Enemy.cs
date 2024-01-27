using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy 
{
    [SerializeField]
    private float boringness = 0.50f;
    public Slider LaghBar;

    private Tuple<HumourType, HumourType> Likes;
    private HumourType DisLike;

    public Enemy(float boringness, Tuple<HumourType, HumourType> likes, HumourType disLike)
    {
        this.boringness = boringness;
        Likes = likes;
        DisLike = disLike;
    }

    public void Action(Card card)
    {
        float LaughPower = card.GetLaughPower();
        foreach (HumourType card_humor in card.GetEffects())
        {
            if ((Likes.Item1 == card_humor) || (Likes.Item2 == card_humor))
            {
                LaughPower += 2;
            }
            else if (DisLike == card_humor)
            {
                LaughPower -= 2;
            }
        }
        boringness += LaughPower;
    }

    public float Get_LaughPower()
    { 
        return boringness; 
    }
}