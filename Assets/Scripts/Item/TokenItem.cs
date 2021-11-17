using System;

[Serializable]
public class TokenItem : Item
{
    public TokenItem(string name, string description, ItemType itemType, ItemRarity rarity) : base(name, description, itemType.ToString(), rarity.ToString(), 0)
    {

    }
}
