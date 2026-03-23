using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;

    [SerializeField] private GameObject SpawnPoint;

    public Wave[] waves;

    private int currentWaveIndex = 0;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            SpawnWave();
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);
        }
    }

}

[System.Serializable]
public class Wave
{
   public Evil[] enemies;
   public float timeToNextEnemy
}