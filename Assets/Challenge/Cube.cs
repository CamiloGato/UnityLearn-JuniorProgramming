using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Material material;
    
    void Start()
    {
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one * 1.3f;

    }
    
    void Update()
    {
        material.color = new Color(Mathf.Sin(Time.time), Mathf.Cos(Time.time), 0.5f);
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
