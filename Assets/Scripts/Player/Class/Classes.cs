public class Classes
{
    public static readonly PlayerClass WARRIOR = new PlayerClass("warrior", new ClassInventory(ItemType.Sword, ItemType.Helm, ItemType.Armor), new StatData(10f, 10f), new StatData(1f, 2f), new StatData(1f, 2f));
    public static readonly PlayerClass WIZARD = new PlayerClass("wizard", new ClassInventory(ItemType.Staff, ItemType.Spell, ItemType.Armor), new StatData(10f, 10f), new StatData(1f, 2f), new StatData(1f, 2f));
    public static readonly PlayerClass PRIEST = new PlayerClass("wizard", new ClassInventory(ItemType.Wand, ItemType.Book, ItemType.Armor), new StatData(10f, 10f), new StatData(1f, 2f), new StatData(1f, 2f));
}
