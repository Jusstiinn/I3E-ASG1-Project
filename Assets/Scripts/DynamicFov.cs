/*
* Author: Justin Chua
* Date: 11/6/2026
* Description: Script for dynamically adjusting FOV based on player movement
*/

using UnityEngine;
using StarterAssets;

public class DynamicFOV : MonoBehaviour
{
    public float idleFOV = 70f;
    public float movingFOV = 85f;
    public float smoothSpeed = 8f;

    private Camera cam;
    private StarterAssetsInputs input;

    private void Start()
    {
        // Get camera
        cam = GetComponent<Camera>();

        // Finds player input
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            input = player.GetComponent<StarterAssetsInputs>();
        }
    }

    private void Update()
    {
        // Stop if player not found
        if (input == null) 
        {
            return;
        }

        // Change FOV based on movement
        if (input.move != Vector2.zero)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, movingFOV, Time.deltaTime * smoothSpeed);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, idleFOV, Time.deltaTime * smoothSpeed);
        }
    }
}
