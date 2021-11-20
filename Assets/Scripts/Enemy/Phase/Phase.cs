﻿using System;
using UnityEngine;

[Serializable]
public class Phase
{
    public string name;
    public float duration;
    public Attack[] attacks;
    public Movement[] movements;
    public Transition transition;
    
    private float attackTime = 0f;

    public void Start()
    {
        if (attacks != null)
        {
            for (int i = 0; i < attacks.Length; ++i)
            {
                if (attacks[i].name != null)
                {
                    foreach (Attack attack in AttackBuilder.attacks)
                    {
                        if (attacks[i].name == attack.name) attacks[i] = Attack.Override(attack, attacks[i]);
                    }
                }
                //imagine an enemy that shoots from the mouse. HA. Ha. ha.. ?
                attacks[i].onMouse = false;
            }
        }

        if (movements != null)
        {
            for (int i = 0; i < movements.Length; ++i)
            {
                if (movements[i].name != null)
                {
                    foreach (Movement movement in MovementBuilder.movements)
                    {
                        if (movements[i].name == movement.name) movements[i] = Movement.Override(movement, movements[i]);
                    }
                }
            }
        }
    }

    public void Run(Enemy enemy, Character character, ObjectPool pool)
    {
        if (attacks != null)
        {
            if (attackTime >= 20f / enemy.stats.attackSpeed)
            {
                foreach (Attack attack in attacks)
                {
                    attack.Shoot(enemy, character, pool);
                }
                attackTime = 0f;
            }
        }
        if (movements != null)
        {
            foreach (Movement movement in movements)
            {
                movement.Run(enemy, character);
            }
        }
    }

    public void IncrementAttackTime(float f)
    {
        attackTime += f;
    }
}
