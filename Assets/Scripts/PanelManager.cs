/*
* Author: Justin Chua
* Date: 11/6/2026
* Description: Script for managing game UI panels
*/

using UnityEngine;
using UnityEngine.AI;

public class PanelManager : MonoBehaviour
{
    EnemyScript enemyScript;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject escapedPanel;
    [SerializeField] public NavMeshAgent enemyAgent;

    void Start()
    {
        //make sure only hud panel is active at start
        hudPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        escapedPanel.SetActive(false);
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
    }
    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
        hudPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        enemyAgent.isStopped = false;
        enemyScript.hasDied = false;
    }
}