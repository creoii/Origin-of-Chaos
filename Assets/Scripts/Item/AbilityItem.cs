using System;
using UnityEngine;

[Serializable]
public class AbilityItem : Item
{
    public AbilityItem(string name, string description, ItemType itemType, ItemRarity rarity, int maxSigils) : base(name, description, itemType.ToString(), rarity.ToString(), maxSigils)
    {

    }

    public void Activate()
    {
        Debug.Log(name + " activated");
    }
}
