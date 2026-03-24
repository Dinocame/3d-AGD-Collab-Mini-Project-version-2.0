using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    public float lives = 6f;

    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
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
}
