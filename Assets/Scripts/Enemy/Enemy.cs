using System;
using System.Collections.Generic;
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

    public List<Phase> phaseList = new List<Phase>();
    private Vector3 origin;
    private Vector3 position;
    private Phase currentPhase;
    public bool phaseRunning = true;
    public List<StatusEffect> activeEffects = new List<StatusEffect>();
    public GameObject targetCharacter;

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

    public void Start(Vector3 origin)
    {
        stats.health = stats.maxHealth;
        this.origin = origin;
        SetPosition(origin);
        targetCharacter = GameObject.FindGameObjectWithTag("Character");
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
                phaseList.Add(phase);
                phase.Start(this, targetCharacter);
            }
        }
        currentPhase = phases[0];
    }

    public void UpdatePhase(ObjectPool pool)
    {
        if (targetCharacter.activeInHierarchy)
        {
            if (!phaseRunning)
            {
                currentPhase.Run(this);
                phaseRunning = true;
                currentPhase = GetNextPhase(currentPhase);
            }
            else
            {
                currentPhase.Update(this, targetCharacter, pool);
            }
            currentPhase.IncrementAttackTime(Time.deltaTime);
        }
    }

    public Phase GetNextPhase(Phase phase)
    {
        foreach (Phase phase1 in phaseList)
        {
            if (phase1.name.Equals(phase.transition.nextPhase)) return phase;
        }

        if (phaseList.IndexOf(phase) + 1 >= phaseList.Count) return phaseList[0];
        else return phaseList[phaseList.IndexOf(phase) + 1];
    }

    public void AddStatusEffect(StatusEffect effect)
    {
        bool apply = true;
        foreach (StatusEffect active in activeEffects)
        {
            if (active.name.Equals(effect.name)) apply = false;
        }

        if (apply)
        {
            activeEffects.Add(effect);
            effect.Apply(this);
        }
    }

    public void Damage(float amount)
    {
        if (stats.health - amount < 0)
        {
            //character.UpdateLeveling(xp);
            Kill();
        }
        else stats.health -= amount;
    }

    private void Kill()
    {
        stats.health = 0;
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 GetPosition()
    {
        return position;
    }

    public Vector3 GetOrigin()
    {
        return origin;
    }
}
