using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [HideInInspector] 
    public GameObject currentCollectible;
    public GameObject currentDoor;
    public Animator animator;
    public int crystalCount = 0;
    public int score = 0;

    void OnTriggerEnter(Collider other)
    {
        
        /*
        if (other.CompareTag("Door"))
        {
            currentDoor = other.gameObject;
        }
        */
    }

    void OnInteract()
    {   
        /* Check if the player is near a door and open it
        if (currentDoor != null)
        {
            Debug.Log("Player is INTERACTING WITH DOOOROR.");
            animator = currentDoor.GetComponentInParent<Animator>();
            if (animator != null)
            {
                Debug.Log("Player is TRIGGING.");
                if (animator.GetBool("IsOpen") == false)
                {
                    animator.SetBool("IsOpen", true);
                    animator.SetTrigger("OpenDoor"); 
                }
                else if (animator.GetBool("IsOpen") == true)
                {
                    animator.SetBool("IsOpen", false);
                    animator.SetTrigger("CloseDoor");
                }
            }
            currentDoor = null;
        }
            */

    }
}
