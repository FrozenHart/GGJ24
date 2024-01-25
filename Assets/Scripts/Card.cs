using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    private string name;
    private int mana_cost;
    private List<Efects> efects;
    private int Laugh_power;
    private string Description;

    public Card(string name,int mana_cost,List<Efects> efects, int Laugh_power,string Description)
    {
        this.name = name;
        this.efects = efects;
        this.mana_cost = mana_cost;
        this.Laugh_power = Laugh_power;
        this.Description = Description;
    }
    public string get_name()
    {
        return name;
    }

    public int get_mana_cost()
    {
        return mana_cost;
    }

    public List<Efects> get_efects()
    {
        return efects;
    }

    public int get_Laugh_power()
    { 
        return Laugh_power;
    }

    public string get_Description()
    {
        return Description;
    }
}
