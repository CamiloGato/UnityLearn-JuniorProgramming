using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager2 : MonoBehaviour
{
    [ SerializeField ] GameObject[] animalPrefabs;
    [ SerializeField ] float spawnRangeX = 20;
    [SerializeField] float spawnRangeZ = 15;
    [ SerializeField ] float spawnPosZ = 20;
    [SerializeField] private float spawnPosX = 20;
    [ SerializeField ] float startDelay = 2;
    [ SerializeField ] float spawnInterval = 1.5f;
    
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
        InvokeRepeating(nameof(SpawnRandomAnimalHorizontal), startDelay, spawnInterval);
    }
    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    private void SpawnRandomAnimalHorizontal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int randomCoordinate = Random.Range(0, 2) * 2 - 1;
        Vector3 spawnPos = new Vector3(spawnPosX * randomCoordinate, 0, Random.Range(1, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(transform.rotation.x, 
            randomCoordinate * -90, transform.rotation.z));
    }
    
}
