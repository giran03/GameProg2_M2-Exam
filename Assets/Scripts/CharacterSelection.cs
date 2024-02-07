using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CharacterStats
{
    public string name;
    public int health;
    public int speed;
    public int defense;
    public int mana;
}

public class CharacterSelection : MonoBehaviour
{
    [Header("Character Selection")]
    public Transform characterParent;
    public TMP_Text selectedCharacterText;
    private GameObject[] characters;
    private int currentIndex = 0;

    [Header("Stats")]
    public CharacterStats[] characterStats;

    private void Start()
    {
        characters = new GameObject[characterParent.childCount];
        for (int i = 0; i < characterParent.childCount; i++)
        {
            characters[i] = characterParent.GetChild(i).gameObject;
        }

        UpdateSelectedCharacterText();
        ToggleCharacterVisibility();
    }

    public void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % characters.Length;
        UpdateSelectedCharacterText();
        ToggleCharacterVisibility();
    }

    public void PreviousCharacter()
    {
        currentIndex = (currentIndex + characters.Length - 1) % characters.Length;
        UpdateSelectedCharacterText();
        ToggleCharacterVisibility();
    }

    private void UpdateSelectedCharacterText()
    {
        CharacterStats stats = characterStats[currentIndex];
        selectedCharacterText.text = stats.name + "\n\n" +
                                      "Health: " + stats.health + "\n" +
                                      "Mana: " + stats.mana + "\n" +
                                      "Defense: " + stats.defense + "\n" +
                                       "Speed:" + stats.speed;
    }

    private void ToggleCharacterVisibility()
    {
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        characters[currentIndex].SetActive(true);
    }
}
