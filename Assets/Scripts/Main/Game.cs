using UnityEngine;

public class Game : MonoBehaviour
{
    public ItemBuilder itemBuilder = new ItemBuilder();

    void Awake()
    {
        itemBuilder.readAndStoreData();
    }
}
