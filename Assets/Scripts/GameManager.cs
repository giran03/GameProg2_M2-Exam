using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] GameObject[] characterPrefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] KeyCode mainMenuKey = KeyCode.P;

    void Awake()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        // Loop through all character prefabs
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            // Instantiate each character prefab
            GameObject prefab = characterPrefabs[i];

            // Activate only the selected character
            prefab.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            prefab.SetActive(i == selectedCharacter);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(mainMenuKey))
            MainMenu_Handler.OnSceneChanged.Invoke("MainMenu");
    }
}
