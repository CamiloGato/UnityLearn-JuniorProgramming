using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft3 : MonoBehaviour
{
    private PlayerController3 playerControllerScript;
    private SpawnManager3 spawnManagerScript;
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager3>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * spawnManagerScript.speed));
        }
        if (transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
