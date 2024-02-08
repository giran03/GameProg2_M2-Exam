using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
   
    public GameObject[] characters;
    public int selectedCharacter = 0; 
    public TMP_Text selectedCharacterText;

    [Header("Stats")]
    public CharacterStats[] characterStats;

    

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        UpdateSelectedCharacterText();
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
        UpdateSelectedCharacterText();
    }

    public void UpdateSelectedCharacterText()
    {
        CharacterStats stats = characterStats[selectedCharacter];
        selectedCharacterText.text = stats.name + "\n\n" +
                                      "Health: " + stats.health + "\n" +
                                      "Mana: " + stats.mana + "\n" +
                                      "Defense: " + stats.defense + "\n" +
                                       "Speed:" + stats.speed;
    }
    
    

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

}