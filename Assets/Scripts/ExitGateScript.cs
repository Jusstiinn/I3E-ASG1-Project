/*
* Author: Justin Chua
* Date: 12/6/2026
* Description: Script for opening the gate when player collects 50 crystals and playing a sound effect when the gate opens.
*/

using UnityEngine;

public class ExitGateScript : MonoBehaviour
{
    PlayerScript playerScript;
    Animator animator;
    AudioSource audioSource;
    private bool opened = false;

    //get playerscript and check if player has all 50 crystals
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (playerScript != null && playerScript.crystalCount >= 5 && !opened)
        {
            Debug.Log("Exit gate opened!");
            //open exit gate
            animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("OpenGate");
                audioSource.Play();
            }
            opened = true;
        }
    }
}
