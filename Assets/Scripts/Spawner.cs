using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;


    int remainingEnemies;
    int enemiesAlive;
    float nextSpawnTime;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        if(remainingEnemies>0 && Time.time > nextSpawnTime)
        {
            remainingEnemies--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        enemiesAlive--;
        if (enemiesAlive == 0)
        {
            NextWave();
        }
        
    }

    void NextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];

            
            remainingEnemies = currentWave.enemyCount;
            enemiesAlive = remainingEnemies;
        }
        
    }


    [System.Serializable]
    public class Wave
    {

        public int enemyCount;
        public float timeBetweenSpawns;

    }
}
