using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class TransitionBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Transitions";

    public static List<Transition> transitions = new List<Transition>();

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
            Transition transition = JsonUtility.FromJson<Transition>(new StreamReader(file).ReadToEnd());
            transitions.Add(transition);
        }
    }
}
