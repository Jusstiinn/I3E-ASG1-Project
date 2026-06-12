using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AITarget : MonoBehaviour
{
    public Transform target;
    public float attackDistance;
    private NavMeshAgent agent;
    private float distance;
    private bool attacking;

    // Start to get navmesh agent
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //Wait for 1.5 seconds before moving again
    IEnumerator Wait()
    {
        agent.isStopped = true;

        yield return new WaitForSeconds(2f);

        agent.isStopped = false;
        attacking = false;
    }

    // Update function to check distance to target and attack if within range
    void Update()
    {
        if (target != null)
        {
            distance = Vector3.Distance(transform.position, target.position);

            if (distance <= attackDistance)
            {
                if (!attacking)
                {
                    attacking = true;
                    StartCoroutine(Wait());
                }
            }
            else
            {
                agent.destination = target.position;
            }
        }
            
    }
}

