using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public float speed;
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float spawnDelay = 2f;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController3 playerControllerScript;
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), spawnTime, spawnDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
    }
    
    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
        }
    }
    
    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
    }

}
