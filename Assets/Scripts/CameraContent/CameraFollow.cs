using BallContent;
using UnityEngine;

namespace CameraContent
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private float _smoothSpeed = 0.125f;
        [SerializeField] private Vector3 _offset;
        private Vector3 _desiredPosition;
        private Vector3 _smoothedPosition;
        
        private void LateUpdate()
        {
            if (!_ball.IsMoving) return;
            
            Follow();
        }

        private void Follow()
        {
            _desiredPosition = _ball.transform.position + _offset;
            _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed);
            transform.position = _smoothedPosition; 
        }
    }
}
