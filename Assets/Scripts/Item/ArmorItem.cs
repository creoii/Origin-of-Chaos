using System;

[Serializable]
public class ArmorItem : Item
{
    public ArmorItem(string name, string description, ItemType itemType, ItemRarity rarity, int maxSigils) : base(name, description, itemType.ToString(), rarity.ToString(), maxSigils)
    {

    }
}
