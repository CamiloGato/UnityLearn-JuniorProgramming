using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCar1 : MonoBehaviour
{

    [SerializeField] private float speed = 10f;

    private void Update()
    {

        transform.Translate(Vector3.forward * (speed * Time.deltaTime) );

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
    
}
