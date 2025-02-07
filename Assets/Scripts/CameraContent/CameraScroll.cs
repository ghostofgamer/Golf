using UnityEngine;

namespace CameraContent
{
    [RequireComponent(typeof(Camera))]
    public class CameraScroll : MonoBehaviour
    {
        private const string MouseScrollWheel ="Mouse ScrollWheel";
        
        private Camera _camera;
        private float _minValue = 45f;
        private float _maxValue = 100f;
        private float _scroll;
        private float _sensitivity = 10f;
        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            _scroll = Input.GetAxis(MouseScrollWheel);
            _camera.fieldOfView -= _scroll * _sensitivity;
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, _minValue, _maxValue);
        }
    }
}