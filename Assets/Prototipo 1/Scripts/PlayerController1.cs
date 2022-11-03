using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject cameraInside;
    [SerializeField] private int playerId;
    [SerializeField] private string keyCamera;
    
    private const float Speed = 20.0f;
    private const float TurnSpeed = 45.0f;
    private float _horizontalInput;
    private float _verticalInput;
    
    private bool _isInside;
    
    void Update()
    {

        _horizontalInput = Input.GetAxis("Horizontal" + playerId);
        _verticalInput = Input.GetAxis("Vertical" + playerId);

        transform.Translate(Vector3.forward * (Time.deltaTime * Speed * _verticalInput));
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * _horizontalInput);

        if (Input.GetKeyDown(keyCamera))
        {
            _isInside = !_isInside;
        }

        if (_isInside)
        {
            cameraMain.SetActive(false);
            cameraInside.SetActive(true);
        }
        else
        {
            cameraMain.SetActive(true);
            cameraInside.SetActive(false);
        }

    }

}