using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    public Character character;
    public Canvas canvas;
    public Image healthBar;
    public Image[] classInventory = new Image[4];

    void Start()
    {
        character = GetComponentInParent<Character>();
        canvas = GetComponent<Canvas>();
        healthBar.color = Color.green;
    }

    private void Update()
    {
        UpdateHealthBar();
        UpdateInventory();
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3(character.stats.health / character.stats.maxHealth, 1f, 1f);

        if (character.stats.health < character.stats.maxHealth * .2f) healthBar.color = Color.red;
        else if (character.stats.health < character.stats.maxHealth * .5f) healthBar.color = Color.yellow;
        else healthBar.color = Color.green;
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < 2; ++i)
        {
            Item item = character.playerClass.classInventory.slots[i].item;
            if (item.sprite != null)
            {
                SpriteUtil.SetSprite(classInventory[i], "Sprites/Items/" + item.sprite);
            }
        }
    }
}
