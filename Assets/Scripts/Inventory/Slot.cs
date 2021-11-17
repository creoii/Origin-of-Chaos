public class Slot
{
    public ItemType slotType = ItemType.All;
    public bool empty = true;
    public Item Item { get; set; }

    public Slot(ItemType slotType)
    {
        this.slotType = slotType;
    }

    public Slot()
    {
        this.slotType = ItemType.All;
    }

    public bool CanSetItem(Item item)
    {
        if (slotType != ItemType.All) return item.itemType == slotType.ToString();
        else return true;
    }

    public void SetItem(Item item)
    {
        this.Item = item;
        empty = false;
    }

    public void RemoveItem()
    {
        this.Item = null;
        empty = true;
    }
}
