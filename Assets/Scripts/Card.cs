using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    private string Name;
    private int ManaCost;
    private List<Effects> Effects;
    private int LaughPower;
    private string Description;

    public Card(string name, int manaCost, List<Effects> effects, int laughPower, string description)
    {
        Name = name;
        Effects = effects;
        ManaCost = manaCost;
        LaughPower = laughPower;
        Description = description;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetManaCost()
    {
        return ManaCost;
    }

    public List<Effects> GetEffects()
    {
        return Effects;
    }

    public int GetLaughPower()
    { 
        return LaughPower;
    }

    public string GetDescription()
    {
        return Description;
    }
}
