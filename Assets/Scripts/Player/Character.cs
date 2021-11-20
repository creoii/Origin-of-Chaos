using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Character : MonoBehaviour
{
    public ObjectPool pool;
    public PlayerInterface playerInterface;
    public PlayerClass playerClass = Classes.Warrior;
    public StatData stats;
    public LevelData level = new LevelData();
    public List<StatusEffect> activeEffects = new List<StatusEffect>();

    private Vector3 movement;
    private float movementModifier = .1f;

    void Awake()
    {
        stats = playerClass.baseStats;
    }

    void Start()
    {
        //This will all be rewritten when the inventory is manipulatable from the game screen
        if (playerClass.classInventory.slots[0] == null) Debug.Log("null");
        playerClass.classInventory.slots[0].SetItem(ItemBuilder.weapons[0]);
        playerClass.classInventory.slots[1].SetItem(ItemBuilder.abilities[0]);

        pool = GetComponentInChildren<ObjectPool>();
        playerInterface = GetComponentInChildren<PlayerInterface>();
        StartInventory(playerClass.classInventory);

        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Characters/Classes/" + playerClass.sprite);

        StartCoroutine(UpdateRegeneration(stats.healthRegeneration, stats.manaRegeneration));
    }

    void Update()
    {
        UpdateMovement();
        UpdateInventory(playerClass.classInventory);
        if (Input.GetKey(KeyCode.Mouse0)) UpdateAttacks(playerClass.classInventory);
        if (Input.GetKey(Game.settings.useAbilityKey)) UpdateAbilities();
    }

    void UpdateMovement()
    {
        if (stats.speed > 0)
        {
            if (Input.GetKey(Game.settings.leftKey)) movement += Vector3.left;
            if (Input.GetKey(Game.settings.downKey)) movement += Vector3.down;
            if (Input.GetKey(Game.settings.upKey)) movement += Vector3.up;
            if (Input.GetKey(Game.settings.rightKey)) movement += Vector3.right;

            movement *= stats.speed * Time.deltaTime;
            if (movement != Vector3.zero)
            {
                transform.position += movement * movementModifier;
                movement = Vector3.zero;
            }
        }

        if (Input.GetKey(Game.settings.rotateLeftKey)) transform.Rotate(Vector3.forward * Game.settings.rotationSpeed * Time.deltaTime);
        if (Input.GetKey(Game.settings.rotateRightKey)) transform.Rotate(Vector3.forward * -Game.settings.rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(Game.settings.resetRotationKey)) transform.rotation = Quaternion.identity;
    }

    void StartInventory(ClassInventory inventory)
    {
        WeaponItem weapon = inventory.slots[0].item as WeaponItem;
        weapon.Start();
        weapon.sigils[0] = ItemBuilder.sigils[0];
    }

    void UpdateInventory(ClassInventory inventory)
    {
        if (!inventory.slots[0].empty)
        {
            (inventory.slots[0].item as WeaponItem).IncrementAttackTime(Time.deltaTime);
        }

        if (!inventory.slots[1].empty)
        {
            (inventory.slots[1].item as AbilityItem).IncrementAttackTime(Time.deltaTime);
        }
    }

    void UpdateAttacks(ClassInventory inventory)
    {
        if (stats.attackSpeed > 0)
        {
            if (!inventory.slots[0].empty)
            {
                (inventory.slots[0].item as WeaponItem).Use(this);
            }
        }
    }

    void UpdateAbilities()
    {
        if (playerClass.classInventory.slots[1] != null || (!playerClass.classInventory.slots[1].empty))
        {
            AbilityItem ability = playerClass.classInventory.slots[1].item as AbilityItem;
            ability.Activate(this);
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

    public void UpdateLeveling(float xp)
    {
        level.xp += xp;
        if (level.xp > LevelData.XpRequired(level.level) && level.level < 40) ++level.level;
    }

    IEnumerator UpdateRegeneration(float amount, float manaAmount)
    {
        for (;;) {
            Heal(amount);
            playerInterface.UpdateHealthBar();
            HealMana(manaAmount);
            playerInterface.UpdateManaBar();
            yield return new WaitForSeconds(1f);
        }
    }

    public void Heal(float amount)
    {
        if (stats.health + amount > stats.maxHealth)
        {
            stats.health = stats.maxHealth;
        }
        else stats.health += amount;
        playerInterface.UpdateHealthBar();
    }

    public void HealMana(float amount)
    {
        if (stats.mana + amount > stats.maxMana)
        {
            stats.mana = stats.maxMana;
        }
        else stats.mana += amount;
        playerInterface.UpdateManaBar();
    }

    public void Damage(float amount)
    {
        if (stats.health - amount < 0)
        {
            Kill();
        }
        else stats.health -= amount;
        playerInterface.UpdateHealthBar();
    }

    public void DamageMana(float amount)
    {
        if (stats.mana - amount < 0)
        {
            stats.mana = 0;
        }
        else stats.mana -= amount;
        playerInterface.UpdateManaBar();
    }

    private void Kill()
    {
        stats.health = 0;
        gameObject.SetActive(false);
    }
}
