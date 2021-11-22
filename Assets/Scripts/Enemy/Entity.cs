using UnityEngine;
using System.Collections.Generic;

public class Entity : MonoBehaviour
{
    public Enemy enemy;
    public Character targetCharacter;
    public ObjectPool pool;
    private Phase currentPhase;
    public List<StatusEffect> activeEffects = new List<StatusEffect>();
    public bool phaseRunning = true;

    void Start()
    {
        enemy = EnemyBuilder.enemies[0];
        enemy.Start(targetCharacter, transform.position);
        pool = GetComponentInChildren<ObjectPool>();
        currentPhase = enemy.phases[0];

        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Characters/Enemies/" + enemy.sprite);
    }

    void Update()
    {
        enemy.SetPosition(transform.position);
        if (targetCharacter.isActiveAndEnabled)
        {
            if (!phaseRunning)
            {
                StartCoroutine(currentPhase.Run(this));
                phaseRunning = true;
                currentPhase = enemy.GetNextPhase(currentPhase);
            }
            else
            {
                currentPhase.Update(this, targetCharacter, pool);
            }
            currentPhase.IncrementAttackTime(Time.deltaTime);
        }
    }

    public void AddStatusEffect(StatusEffect effect)
    {
        bool apply = true;
        foreach (StatusEffect active in activeEffects)
        {
            if (active.name.Equals(effect.name)) apply = false;
        }

        if (apply && isActiveAndEnabled)
        {
            activeEffects.Add(effect);
            StartCoroutine(effect.Apply(this));
        }
    }

    public void Damage(float amount)
    {
        if (enemy.stats.health - amount < 0)
        {
            targetCharacter.UpdateLeveling(enemy.xp);
            Kill();
        }
        else enemy.stats.health -= amount;
    }

    private void Kill()
    {
        enemy.stats.health = 0;
        gameObject.SetActive(false);
    }
}
