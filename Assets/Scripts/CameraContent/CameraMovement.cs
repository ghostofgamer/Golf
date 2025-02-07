using UnityEngine;

namespace CameraContent
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private Vector2 _minBounds;
        [SerializeField] private Vector2 _maxBounds;
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private float _smoothTime = 0.3f;
        
        private bool _isCanMove;
        private Vector3 _lastMousePosition;
        private bool _isDragging = false;
        
        private void OnEnable()
        {
            _ball.StopedBall += AllowMove;
            _ball.StartDragBall += ProhibitionDrag;
        }

        private void OnDisable()
        {
            _ball.StopedBall -= AllowMove;
            _ball.StartDragBall -= ProhibitionDrag;
        }

        private void Update()
        {
            if (!_isCanMove)
            {
                _isDragging = false;
                _cameraFollow.enabled = true;
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _cameraFollow.enabled = false;
                _isDragging = true;
                _lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && _isDragging)
            {
                Vector3 delta = Input.mousePosition - _lastMousePosition;
                Vector3 newPosition =
                    transform.position - new Vector3(delta.x, delta.y, 0) * moveSpeed * Time.deltaTime;

                newPosition.x = Mathf.Clamp(newPosition.x, _minBounds.x, _maxBounds.x);
                newPosition.y = Mathf.Clamp(newPosition.y, _minBounds.y, _maxBounds.y);

                transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                // transform.position = newPosition;
                _lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _cameraFollow.enabled = true;
                _isDragging = false;
            }
        }

        private void AllowMove()
        {
           _isCanMove = true; 
        } 

        private void ProhibitionDrag()
        {
            _isCanMove = false;
        } 
    }
}