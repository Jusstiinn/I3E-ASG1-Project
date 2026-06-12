/*
* Author: Justin Chua
* Date: 11/6/2026
* Description: Script for managing game UI panels
*/

using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject escapedPanel;

    void Start()
    {
        //make sure only hud panel is active at start
        hudPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        escapedPanel.SetActive(false);
    }
    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
        hudPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}