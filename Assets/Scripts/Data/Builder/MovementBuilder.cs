using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class MovementBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Movements";

    public static List<Movement> movements = new List<Movement>();

    public void readAndStoreData()
    {
        if (!Directory.Exists(DATA_PATH))
        {
            Directory.CreateDirectory(DATA_PATH);
            return;
        }
        
        IEnumerable<string> files = Directory.EnumerateFiles(DATA_PATH, "*.json", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            Movement movement = JsonUtility.FromJson<Movement>(new StreamReader(file).ReadToEnd());
            Debug.Log(movement.name);
            movements.Add(movement);
        }
    }
}
