using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        // Loop through all character prefabs
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            // Instantiate each character prefab
            GameObject prefab = characterPrefabs[i];
            GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

            // Activate only the selected character
            clone.SetActive(i == selectedCharacter);
        }
    }
}
