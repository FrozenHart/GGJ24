using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    private string name;
    private int manaCost;
    private List<HumourType> effects;
    private int laughPower;
    private string description;

    public Card(string name, int manaCost, List<HumourType> effects, int laughPower, string description)
    {
        this.name = name;
        this.effects = effects;
        this.manaCost = manaCost;
        this.laughPower = laughPower;
        this.description = description;
    }

    public string GetName()
    {
        return name;
    }

    public int GetManaCost()
    {
        return manaCost;
    }

    public List<HumourType> GetEffects()
    {
        return effects;
    }

    public int GetLaughPower()
    { 
        return laughPower;
    }

    public string GetDescription()
    {
        return description;
    }
}
