using UnityEngine;

public class Game : MonoBehaviour
{
    public static GameSettings settings;
    public AttackPresetBuilder attackPresetBuilder = new AttackPresetBuilder();
    public ItemBuilder itemBuilder = new ItemBuilder();

    void Awake()
    {
        settings = new GameSettings();
        attackPresetBuilder.readAndStoreData();
        itemBuilder.readAndStoreData();
    }
}
