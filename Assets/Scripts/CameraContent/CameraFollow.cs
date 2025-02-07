using UnityEngine;

namespace CameraContent
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private float _smoothSpeed = 0.125f;
        [SerializeField] private Vector3 _offset;
        
        private void Start()
        {
        
        }

        void LateUpdate()
        {
            if (!_ball.IsMoving) return;
            
            Vector3 desiredPosition = _ball.transform.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
