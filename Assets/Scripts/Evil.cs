using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evil: MonoBehaviour
{
    private void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
    }

    [SerializeField] private float speed;
    
    private WaveSpawner waveSpawner;

    private float countdown = 5f;
    
    void Update()
    {
        

        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
        }   
    }
}
