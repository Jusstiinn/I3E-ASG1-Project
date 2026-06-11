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

    }
}
