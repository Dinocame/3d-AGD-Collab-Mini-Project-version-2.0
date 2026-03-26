using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    public Transform spawnPoint; 
    private ZombieAnimation anim;          // Handles animations




    public float lives = 6f;

    public float maxLives = 6f;

    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
           anim = GetComponent<ZombieAnimation>();
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }
    public float GetLives()
    {
        return lives;
    }
    public void LoseLives(float f)
    {
        lives -= f;
    }
    public void Respawn(float delay = 0f)
    {
        StartCoroutine(RespawnRoutine(delay));
    }

    private IEnumerator RespawnRoutine(float delay)
    {
       
        if (delay > 0f)
            yield return new WaitForSeconds(delay);

        // Reset health
        lives = maxLives;

        // Move to spawn point safely
        if (spawnPoint != null)
            agent.Warp(spawnPoint.position);

        agent.isStopped = false;

        // Reset animation

    }
}
