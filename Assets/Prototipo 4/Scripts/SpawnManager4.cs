using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager4 : MonoBehaviour
{
    public static int enemyCount;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    
    private int waveEnemyCount = 1;
    private float spawnRange = 9;

    private void Start()
    {
        SpawnEnemyWave(waveEnemyCount);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private void Update()
    {
        if (enemyCount == 0)
        {
            waveEnemyCount++;
            SpawnEnemyWave(waveEnemyCount);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            enemyCount++;
        }
    }
    
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return spawnPos;
    }
}
