/*
* Author: Justin Chua
* Date: 12/6/2026
* Description: Script for AI targetting the player and attacking when within range
*/

using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AITarget : MonoBehaviour
{
    EnemyScript enemyScript;
    public Transform target;
    public float attackDistance;
    private NavMeshAgent agent;
    private float distance;
    [HideInInspector] public bool attacking;

    // Start to get navmesh agent
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
    }

    //Wait for 2 seconds before moving again
    IEnumerator Wait()
    {
        agent.isStopped = true;

        yield return new WaitForSeconds(2f);

        agent.isStopped = false;
        enemyScript.hasAttacked = false;
        attacking = false;
    }

    // Update function to check distance to target and attack if within range
    void Update()
    {
        //check if enemy has killed player
        if(enemyScript.hasDied)
        {
            agent.isStopped = true;
            return;
        }

        if (target != null)
        {
            //check if navmesh is availble
            if(agent != null && agent.enabled)
            {
                distance = Vector3.Distance(transform.position, target.position);

                if (distance <= attackDistance)
                {
                    //attack cooldown
                    if (!attacking)
                    {
                        attacking = true;
                        Debug.Log("Player Damaged!");
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
}

