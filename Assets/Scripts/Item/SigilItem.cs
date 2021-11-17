using System;

[Serializable]
public class SigilItem : Item
{
    public SigilItem(string name, string description, ItemType itemType, ItemRarity rarity) : base(name, description, itemType.ToString(), rarity.ToString(), 0)
    {

    }
}
