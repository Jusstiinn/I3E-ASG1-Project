/*
* Author: Justin Chua
* Date: 12/6/2026
* Description: Script for collectible items that can be picked up by the player, destorying them, playing a sound effect and adding to the crystal count
*/

using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    MeshRenderer meshRenderer;
    CapsuleCollider triggerCollider;
    AudioSource collectibleAudio;
    PlayerScript playerScript;

    void Start()
    {
        collectibleAudio = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        triggerCollider = GetComponent<CapsuleCollider>();
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // get playerscript and update crystal count and call collect function
            playerScript = other.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.crystalCount++;
                Debug.Log("Collected " + playerScript.crystalCount + " crystals!");
                Collect();
            }
        }
    }
    public void Collect()
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }

        if (triggerCollider != null)
        {
            triggerCollider.enabled = false;
        }

        if (collectibleAudio != null && collectibleAudio.clip != null)
            {
                collectibleAudio.PlayOneShot(collectibleAudio.clip);
                Destroy(gameObject, collectibleAudio.clip.length);
            }
            else
            {
                Destroy(gameObject);
            }
    }
}
