using TMPro;
using UnityEngine;

public class InteractionUIManager : MonoBehaviour
{
    PlayerScript playerScript;
    [SerializeField] TMP_Text interactionText;
    [SerializeField] private Camera playerCamera;

    //get playerscript and disable interact text
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        interactionText.enabled = false;
    }

    // check if player is looking at door and if its locked
    void Update()
    {
        //shoot out raycast to check if looking at door
        Ray ray = playerScript.playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        //check if raycast is within range of door
        if (Physics.Raycast(ray, out hit, playerScript.interactDistance))
        {
            if (hit.collider.CompareTag("Door") || (hit.collider.transform.parent != null && hit.collider.transform.parent.CompareTag("Door")))
            {
                //checks if player has key
                if (!playerScript.hasKey)
                {
                    interactionText.text = "E - Locked Door";
                    interactionText.enabled = true;
                }
                else
                {
                    interactionText.text = "E - Open Door";
                    interactionText.enabled = true;
                }
            }
            else
            {
                interactionText.enabled = false;
            }
        }
        else
        {
            interactionText.enabled = false;
        }

    }
}

