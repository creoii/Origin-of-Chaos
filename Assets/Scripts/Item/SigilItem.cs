using System;

[Serializable]
public class SigilItem : Item
{
    public SigilItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), 0)
    {

    }
}
