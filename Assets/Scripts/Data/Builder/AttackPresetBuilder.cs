﻿using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class AttackPresetBuilder
{
    private readonly string DATA_PATH = "Assets/Data/Presets/Attacks";

    public static List<Attack> attacks = new List<Attack>();

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
            Attack attack = JsonUtility.FromJson<Attack>(new StreamReader(file).ReadToEnd());
            attacks.Add(attack);
        }
    }
}