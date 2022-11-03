using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] float spawnDelay = 2f;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController3 playerControllerScript;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnTime, spawnDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
    }
    
    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
