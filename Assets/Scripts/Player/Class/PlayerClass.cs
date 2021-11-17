public class PlayerClass
{
    public string sprite;
    public ClassInventory classInventory;
    public StatData baseStats;
    public StatData minStatLvlIncrease;
    public StatData maxStatLvlIncrease;

    public PlayerClass(string sprite, ClassInventory classInventory, StatData baseStats, StatData minStatLvlIncrease, StatData maxStatLvlIncrease)
    {
        this.sprite = sprite;
        this.classInventory = classInventory;
        this.baseStats = baseStats;
        this.minStatLvlIncrease = minStatLvlIncrease;
        this.maxStatLvlIncrease = maxStatLvlIncrease;
    }
}
