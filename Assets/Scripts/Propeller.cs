using System;
using BallContent;
using Singletons;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }
}
