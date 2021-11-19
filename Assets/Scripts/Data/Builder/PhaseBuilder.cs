using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class PhaseBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Phases";

    public static List<Phase> phases = new List<Phase>();

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
            Phase phase = JsonUtility.FromJson<Phase>(new StreamReader(file).ReadToEnd());
            phases.Add(phase);
        }
    }
}
