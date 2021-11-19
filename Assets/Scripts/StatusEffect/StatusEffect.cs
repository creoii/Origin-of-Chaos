using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class StatusEffect
{
    public string name;
    public float duration;
    public StatData statChange;

    public StatusEffect WithDuration(float duration)
    {
        this.duration = duration;
        return this;
    }

    public StatusEffect WithStrengthMultiplier(float strengthMultiplier)
    {
        statChange.Multiply(new StatData(strengthMultiplier, strengthMultiplier, strengthMultiplier, strengthMultiplier));
        return this;
    }

    public IEnumerator Apply(Character character)
    {
        character.stats.Add(statChange);
        yield return new WaitForSeconds(duration);
        character.stats.Subtract(statChange);
    }
}
