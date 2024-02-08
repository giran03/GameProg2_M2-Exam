using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudHandler : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text manaText;
    [SerializeField] TMP_Text defenseText;
    [SerializeField] TMP_Text speedText;
    (int, int, int, float) playerStats;
    int charIndex;

    private void Start()
    {
        charIndex = PlayerPrefs.GetInt("selectedCharacter");

        switch (charIndex)
        {
            case 0:
                playerStats = Mage.GetVal();
                Debug.Log(playerStats);
                break;
            case 1:
                playerStats = Priest.GetVal();
                break;
            case 2:
                playerStats = Warrior.GetVal();
                break;
            case 3:
                playerStats = Assassin.GetVal();
                break;
        }
    }

    private void Update()
    {
        int roundedSpeed = Mathf.RoundToInt(playerStats.Item4);

        healthText.SetText("Health: " + playerStats.Item1);
        manaText.SetText("Mana: " + playerStats.Item2);
        defenseText.SetText("Defense: " + playerStats.Item3);
        speedText.SetText("Speed: " + roundedSpeed);
    }
}
