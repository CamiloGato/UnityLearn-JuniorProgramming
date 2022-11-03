using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward2 : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    void Update()
    {
        transform.Translate( Vector3.forward * (Time.deltaTime * speed) );
    }
}
