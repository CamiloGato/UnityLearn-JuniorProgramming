using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager1 : MonoBehaviour
{
    [SerializeField] private GameObject _busPrefab;

    private void Start()
    {
        StartCoroutine(SpawnBus());
    }
    
    IEnumerator SpawnBus()
    {
        while (true)
        {
            float randomX = Random.Range(-8f, 8f);
            Vector3 spawnPos = new Vector3(randomX, 0, 180);
            Instantiate(_busPrefab, spawnPos, _busPrefab.transform.rotation);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
