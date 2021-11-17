using UnityEngine;

public class Game : MonoBehaviour
{
    public static GameSettings settings;
    public ItemBuilder itemBuilder = new ItemBuilder();

    void Awake()
    {
        settings = new GameSettings();
        itemBuilder.readAndStoreData();
    }
}
