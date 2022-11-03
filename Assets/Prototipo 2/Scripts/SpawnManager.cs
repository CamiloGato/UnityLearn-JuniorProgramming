using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    [ SerializeField ] GameObject[] animalPrefabs;
    [ SerializeField ] float spawnRangeX = 20;
    [ SerializeField ] float spawnPosZ = 20;
    [ SerializeField ] float startDelay = 2;
    [ SerializeField ] float spawnInterval = 1.5f;
    
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }
    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
