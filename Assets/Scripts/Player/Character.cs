using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Character : MonoBehaviour
{
    public ObjectPool pool;
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
        StartInventory(playerClass.classInventory);

        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Characters/Classes/" + playerClass.sprite);

        StartCoroutine(UpdateRegeneration());
    }

    void Update()
    {
        UpdateMovement();
        UpdateInventory(playerClass.classInventory);
        if (Input.GetKey(KeyCode.Mouse0)) UpdateAttacks(playerClass.classInventory);
        if (Input.GetKey(Game.settings.useAbilityKey)) UpdateAbilities();

        //for testing status effects
        if (Input.GetKeyDown(KeyCode.R))
        {
            activeEffects.Add(StatusEffectBuilder.statusEffects[0].WithDuration(10f).WithStrengthMultiplier(1.5f));
            UpdateActiveEffects();
        }
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

    void UpdateActiveEffects()
    {
        foreach (StatusEffect effect in activeEffects)
        {
            StartCoroutine(effect.Apply(this));
        }
    }

    void UpdateLeveling(float xp)
    {
        level.Xp += xp;

        if (level.Xp > LevelData.XpRequired(level.Level))
        {
            if (level.Level < 40) ++level.Level;
        }
    }

    IEnumerator UpdateRegeneration()
    {
        for (;;) {
            Heal(.5f);
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
    }

    public void Damage(float amount)
    {
        if (stats.health - amount < 0)
        {
            stats.health = 0;
            gameObject.SetActive(false);
        }
        else stats.health -= amount;
    }
}
