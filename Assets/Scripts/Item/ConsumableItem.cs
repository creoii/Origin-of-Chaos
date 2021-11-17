using System;

[Serializable]
public class ConsumableItem : Item
{
    public ConsumableItem(string name, string description, ItemType itemType, ItemRarity rarity) : base(name, description, itemType.ToString(), rarity.ToString(), 0)
    {

    }
}
