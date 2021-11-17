using UnityEngine;

public class Player : MonoBehaviour
{
    public Character characterPrefab;
    public int maxCharacters;
    public Character[] characters;
    public int currentCharacter = 0;

    private void Start()
    {
        maxCharacters = 3;
        characters = new Character[maxCharacters];
        characters[0] = Instantiate(characterPrefab, transform.position, Quaternion.identity) as Character;
        characters[1] = Instantiate(characterPrefab, transform.position, Quaternion.identity) as Character;
        characters[2] = Instantiate(characterPrefab, transform.position, Quaternion.identity) as Character;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) currentCharacter = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha1)) currentCharacter = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) currentCharacter = 2;
    }
}
