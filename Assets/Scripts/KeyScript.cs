/*
* Author: Justin Chua
* Date: 12/6/2026
* Description: Script for key to update whether player has it and to destroy itself
*/

using UnityEngine;

public class KeyScript : MonoBehaviour
{
    PlayerScript playerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // get playerscript and update haskey to true
            playerScript = other.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.hasKey = true;
                Debug.Log("Key collected!");
                Destroy(gameObject);
            }
        }
    }
}
