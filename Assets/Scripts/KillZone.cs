/*
* Author: Justin Chua
* Date: 11/6/2026
* Description: Script for killing player and respawning them
*/

using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject escapedPanel;
    PlayerScript playerScript;
//get player script
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    } 
    private void OnTriggerEnter(Collider other)
    {
        //get the top most parent's transform
        Transform playerRoot = other.transform.root;

        if (other.CompareTag("Player") || playerRoot.CompareTag("Player"))
        {
            Debug.Log("Player entered kill zone");
            Respawn(playerRoot);
        }
    }
    //respawn function to move character controller
    public void Respawn(Transform playerTransform)
    {
        Debug.Log("Respawn running");

        //Switch panels and unlock cursor
        hudPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //reset health
        playerScript.health = 3;
        
        //disable the cc so character can teleport.
        CharacterController cc = playerTransform.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            playerTransform.position = new Vector3(0f, 0f, -12f);
            cc.enabled = true;
        }
    }
}
