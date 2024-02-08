using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] GameObject[] characterPrefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] KeyCode mainMenuKey = KeyCode.P;
    [SerializeField] KeyCode controlsKey = KeyCode.K;
    [SerializeField] GameObject controlsOverlay;
    [SerializeField] GameObject controlsInfoText;
    bool buttonToggle;

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
            CharacterStats(selectedCharacter, prefab);
            prefab.SetActive(i == selectedCharacter);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(mainMenuKey))
            MainMenu_Handler.OnSceneChanged.Invoke("MainMenu");
        if (Input.GetKeyDown(controlsKey))
        {
            buttonToggle = !buttonToggle;
            controlsOverlay.SetActive(buttonToggle);
            controlsInfoText.SetActive(!buttonToggle);
        }
    }

    void CharacterStats(int index, GameObject prefab)
    {
        // pass player stats | health, mana, defense, speed
        switch (index)
        {
            case 0:
                Mage.Create(prefab, 100, 130, 70, 105);
                break;
            case 1:
                Priest.Create(prefab, 110, 110, 70, 105);
                break;
            case 2:
                Warrior.Create(prefab, 110, 100, 100, 90);
                break;
            case 3:
                Assassin.Create(prefab, 90, 100, 70, 110);
                break;
        }
    }
}
