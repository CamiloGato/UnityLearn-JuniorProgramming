using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX2 : MonoBehaviour
{
    public float timeDelay;
    public GameObject dogPrefab;
    private float lastSpawnTime;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastSpawnTime > timeDelay)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastSpawnTime = Time.time;
        }
    }
}
