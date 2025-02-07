using System;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }
}
