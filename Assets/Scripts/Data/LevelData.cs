public class LevelData
{
    public float Level { get; set; } = 1;
    public float Xp { get; set; } = 0;

    public static float XpRequired(float level)
    {
        return level * level;
    }
}
