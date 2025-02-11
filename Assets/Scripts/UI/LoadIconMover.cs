using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class LoadIconMover : MonoBehaviour
    {
        private float _speed = 300f;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            SetRandomColor();
        }
        
        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            transform.Rotate(Vector3.forward, _speed * Time.deltaTime);
        }

        private void SetRandomColor()
        {
            if (_image != null)
            {
                Color randomColor = new Color(Random.value, Random.value, Random.value);
                _image.color = randomColor;
            }
        }
    }
}