using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Enemy
{
    public string name;
    public string sprite;
    public float xp;
    public StatData stats;
    public bool isBoss = false;
    public Phase[] phases;

    private Vector3 position;

    public Enemy(string name, string sprite, StatData stats)
    {
        this.name = name;
        this.sprite = sprite;
        this.stats = stats;
    }

    public Enemy(string name, string sprite, StatData stats, bool isBoss) : this(name, sprite, stats)
    {
        this.isBoss = isBoss;
    }

    public void Start()
    {
        stats.health = stats.maxHealth;
        if (phases != null)
        {
            for (int i = 0; i < phases.Length; ++i)
            {
                if (phases[i].name != null)
                {
                    foreach (Phase phase in PhaseBuilder.phases)
                    {
                        if (phases[i].name == phase.name) phases[i] = phase;
                    }
                }
            }

            foreach (Phase phase in phases)
            {
                phase.Start();
            }
        }
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 GetPosition()
    {
        return position;
    }
}
