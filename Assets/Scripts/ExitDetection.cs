/*
* Author: Justin Chua
* Date: 11/6/2026
* Description: Script for detecting when the player reaches the exit and updating UI
*/

using UnityEngine;

public class ExitDetection : MonoBehaviour
{
    KillZone killZone;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject escapedPanel;

    void Start()
    {
        killZone = GameObject.FindGameObjectWithTag("RespawnScript").GetComponent<KillZone>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has reached the exit!");
            killZone.enemyAgent.isStopped = true;
            hudPanel.SetActive(false);
            escapedPanel.SetActive(true);
        }
    }
}
