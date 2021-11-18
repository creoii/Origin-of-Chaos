using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class StatusEffectBuilder
{
    private readonly string DATA_PATH = "Assets/Data/StatusEffects/";

    public static List<StatusEffect> statusEffects = new List<StatusEffect>();

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
            StatusEffect effect = JsonUtility.FromJson<StatusEffect>(new StreamReader(file).ReadToEnd());
            statusEffects.Add(effect);
        }
    }
}
