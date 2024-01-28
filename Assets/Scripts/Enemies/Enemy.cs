using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy 
{
   
    private float boringness ; 
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
        float LaughPower=card.GetLaughPower();
        
       
        foreach (HumourType card_humor in card.GetEffects())
        {
            if ((Likes.Item1 == card_humor) || (Likes.Item2 == card_humor))
            {
                LaughPower += 0.2f;
            }
            else if (DisLike == card_humor)
            {
                LaughPower -= 0.2f;
            }
        }
        if(boringness+LaughPower>100)
        {
            boringness = 1f;
        }
        else
        {
            boringness += LaughPower;
        }
    }

    public float Get_LaughPower()
    { 
        return boringness; 
    }

    public void reset()
    {
        boringness = 0.5f;
    }
}