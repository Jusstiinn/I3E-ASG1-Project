/*
* Author: Justin Chua
* Date: 12/6/2026
* Description: Script for player movement, health and door interactions.
*/
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Camera playerCamera;
    public float interactDistance = 3f;
    [HideInInspector] public GameObject currentCollectible;
    [HideInInspector] public GameObject currentDoor;
    [HideInInspector] public Animator animator;
    [HideInInspector] public int crystalCount = 0;
    [HideInInspector] public bool hasKey = false;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            OnInteract();
        }
    }

    public void OnInteract()
    {
        Debug.Log("interact pressed");
        //cast ray
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            //Check if raycasted object is door
            if (hit.collider.CompareTag("Door") ||(hit.collider.transform.parent != null && hit.collider.transform.parent.CompareTag("Door")))
            {
                //check if haskey
                if (hasKey)
                {
                    Animator animator = hit.collider.GetComponentInParent<Animator>();
                    //set animator state to open and close door
                    if (animator != null)
                    {
                        //Debug.Log("Found animator");

                        bool isOpen = animator.GetBool("IsOpen");
                        animator.SetBool("IsOpen", !isOpen);

                        if (!isOpen)
                            animator.SetTrigger("OpenDoor");
                        else
                            animator.SetTrigger("CloseDoor");
                    }
                }
                else
                {
                    Debug.Log("Door is locked. Find the key!");
                }
            }
        }
    }
}

