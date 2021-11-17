using UnityEngine;

public class Character : MonoBehaviour
{
    public ObjectPool pool;
    public PlayerClass playerClass = Classes.WARRIOR;
    public StatData stats;
    public LevelData level = new LevelData();

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

        //This won't be rewritten for a while I hope
        SpriteUtil.SetSpriteRenderer(GetComponent<SpriteRenderer>(), "Sprites/Characters/Classes/" + playerClass.sprite);
    }

    void Update()
    {
        UpdateMovement();
        UpdateInventory(playerClass.classInventory);
        if (Input.GetKey(KeyCode.Mouse0)) UpdateAttacks(playerClass.classInventory);
        if (Input.GetKey(KeyCode.Space)) UpdateAbilities();
    }

    void UpdateMovement()
    {
        if (stats.speed > 0)
        {
            movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * stats.speed * Time.deltaTime;
            if (movement != Vector3.zero)
            {
                transform.position += movement * movementModifier;
            }
        }

        if (Input.GetKey(Game.settings.rotateLeftKey)) transform.Rotate(Vector3.forward * Game.settings.rotationSpeed * Time.deltaTime);
        if (Input.GetKey(Game.settings.rotateRightKey)) transform.Rotate(Vector3.forward * -Game.settings.rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(Game.settings.resetRotationKey)) transform.rotation = Quaternion.identity;
    }

    void UpdateInventory(ClassInventory inventory)
    {
        if (!inventory.slots[0].empty)
        {
            WeaponItem weapon = inventory.slots[0].Item as WeaponItem;
            weapon.IncrementAttackTime(Time.deltaTime);
        }

        if (!inventory.slots[1].empty)
        {
            AbilityItem ability = inventory.slots[1].Item as AbilityItem;
            ability.IncrementAttackTime(Time.deltaTime);
        }
    }

    void UpdateAttacks(ClassInventory inventory)
    {
        if (stats.attackSpeed > 0)
        {
            if (inventory.slots[0] != null || (!inventory.slots[0].empty))
            {
                WeaponItem weapon = inventory.slots[0].Item as WeaponItem;
                weapon.Use(this);
            }
        }
    }

    void UpdateAbilities()
    {
        if (playerClass.classInventory.slots[1] != null || (!playerClass.classInventory.slots[1].empty))
        {
            AbilityItem ability = playerClass.classInventory.slots[1].Item as AbilityItem;
            ability.Activate(this);
        }
    }

    void UpdateLeveling(float xp)
    {
        level.Xp += xp;

        if (level.Xp > LevelData.XpRequired(level.Level))
        {
            if (level.Level < 40) ++level.Level;
        }
        Debug.Log("level");
    }

    public Character CreateCopy(Vector3 position)
    {
        Character ret = Instantiate(this, position, Quaternion.identity);
        ret.playerClass = playerClass;
        ret.stats = stats;
        return ret;
    }
}
