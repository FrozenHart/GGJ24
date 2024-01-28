using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Card 
{
    private string name;
    private int manaCost;
    private HashSet<HumourType> effects;
    private float laughPower;
    private string description;
    private ShopType type;
    private Image image;

    public Card(string name, int manaCost, HashSet<HumourType> effects, float laughPower, string description, ShopType shopType)//, Image image)
    {
        setName(name);
        setEffects(effects);
        setManaCost(manaCost);
        SetLaughPower(laughPower);
        SetDescription(description);
        SetTipo(shopType);
        //this.image = image;
    }

    public ShopType GetCardType()
    {
        return type;
    }

    public string GetName()
    {
        return name;
    }

    public void setName(string nome) { 
        this.name = nome;
    }

    public int GetManaCost()
    {
        return manaCost;
    }

    public void setManaCost(int mana)
    {
        this.manaCost = mana;
    }

    public HashSet<HumourType> GetEffects()
    {
        return effects;
    }

    public void setEffects(HashSet<HumourType> effects) 
    { 
        this.effects = effects;
    }

    public float GetLaughPower()
    { 
        return laughPower;
    }

    public void SetLaughPower(float laughPower) 
    { 
        this.laughPower = laughPower;
    }

    public string GetDescription()
    {
        return description;
    }

    public void SetDescription(string description)
    {
        this.description = description;
    }

    public ShopType GetShopType()
    {
        return this.type;
    }

    public void SetTipo(ShopType tipo)
    {
        this.type = tipo;
    }

    public override bool Equals(object obj)
    {
        return obj is Card card &&
               name == card.name &&
               manaCost == card.manaCost &&
               EqualityComparer<HashSet<HumourType>>.Default.Equals(effects, card.effects) &&
               laughPower == card.laughPower &&
               description == card.description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, manaCost, effects, laughPower, description);
    }
    public Image Get_Image() 
    {
        return image;
    }
}
