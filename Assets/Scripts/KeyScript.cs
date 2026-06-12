/*
* Author: Justin Chua
* Date: 12/6/2026
* Description: Script for key to update whether player has it and to destroy itself and play audio
*/

using UnityEngine;

public class KeyScript : MonoBehaviour
{
    PlayerScript playerScript;
    [SerializeField] private AudioSource keyCollectAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // get playerscript and update haskey to true
            playerScript = other.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                Debug.Log("Key collected!");
                playerScript.hasKey = true;
                if (keyCollectAudio != null && keyCollectAudio.clip != null)
                {
                    keyCollectAudio.PlayOneShot(keyCollectAudio.clip);
                    Destroy(gameObject, keyCollectAudio.clip.length);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
