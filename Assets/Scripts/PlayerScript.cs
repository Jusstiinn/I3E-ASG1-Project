using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Camera playerCamera;
    public float interactDistance = 3f;
    [HideInInspector] public GameObject currentCollectible;
    [HideInInspector] public GameObject currentDoor;
    [HideInInspector] public Animator animator;
    [HideInInspector] public int crystalCount = 0;
    public void OnInteract()
    {
        Debug.Log("interact pressed");
        //cast ray
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            //Debug.Log("Looking at: " + hit.collider.gameObject.name);

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
    }
}

