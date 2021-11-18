using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    public Character character;
    public Canvas canvas;
    public Image healthBar;

    void Start()
    {
        character = GetComponentInParent<Character>();
        canvas = GetComponent<Canvas>();
        healthBar.color = Color.green;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3(character.stats.health / character.stats.maxHealth, 1f, 1f);

        if (character.stats.health < character.stats.maxHealth * .2f) healthBar.color = Color.red;
        else if (character.stats.health < character.stats.maxHealth * .5f) healthBar.color = Color.yellow;
        else healthBar.color = Color.green;
    }
}
