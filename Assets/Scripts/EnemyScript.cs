/*
* Author: Justin Chua
* Date: 12/6/2026
* Description: Script for Enemy damage and sound effects. 
*/

using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    PlayerScript playerScript;
    AITarget aiTarget;
    AudioSource enemyAudio;
    [HideInInspector] public bool hasAttacked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        aiTarget = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AITarget>();
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aiTarget != null && playerScript != null)
        {
            if (aiTarget.attacking && playerScript.health > 0 && !hasAttacked)
            {
                playerScript.health--;
                hasAttacked = true;
                if (playerScript.health <= 0)
                {
                    Debug.Log("Player has died!");
                }
                else
                {
                    Debug.Log("Player damaged! Health: " + playerScript.health);
                }
                Debug.Log("Player Health: " + playerScript.health);
                if (enemyAudio != null)
                {
                    enemyAudio.PlayOneShot(enemyAudio.clip);
                }
            }
        }
    }
}
