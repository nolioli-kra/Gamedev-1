using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacters : MonoBehaviour
{
    public Character[] charactersToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacters();
    }

    public void SpawnCharacters()
    {
        foreach (Character character in charactersToSpawn)
        {
            if (character.characterPrefab != null)
            {
                GameObject newCharacter = Instantiate(
                    character.characterPrefab,
                    character.spawnPosition,
                    Quaternion.identity
                );
                
                newCharacter.name = character.characterName;
            }
            else
            {
                Debug.Log("No prefab assigned to character attempted to spawn.");
            }
        }
    }
}
