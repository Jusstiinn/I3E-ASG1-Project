/*
* Author: Justin Chua
* Date: 11/6/2026
* Description: Script for managing the UI player will see the when playing the game
*/

using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    PlayerScript playerScript;
    [SerializeField] TMP_Text crystalsShattered;
    [SerializeField] TMP_Text crystalsLeft;
    [SerializeField] TMP_Text livesLeft;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (playerScript != null)
        {
            crystalsShattered.text = "Crystals Shattered: " + playerScript.crystalCount;
            crystalsLeft.text = "Crystals Left: " + (50 - playerScript.crystalCount);
            livesLeft.text = "Lives Left: " + playerScript.health;
        }
    }
}