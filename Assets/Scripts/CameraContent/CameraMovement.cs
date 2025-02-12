using BallContent;
using UnityEngine;

namespace CameraContent
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private BallDragger _ball;
        [SerializeField] private BallMover _ballMover;
        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private Vector2 _minBounds;
        [SerializeField] private Vector2 _maxBounds;

        private bool _isCanMove;
        private Vector3 _lastMousePosition;
        private bool _isDragging = false;

        private void OnEnable()
        {
            _ballMover.StopedBall += AllowMove;
            _ball.StartDragBall += ProhibitionDrag;
        }

        private void OnDisable()
        {
            _ballMover.StopedBall -= AllowMove;
            _ball.StartDragBall -= ProhibitionDrag;
        }

        private void Update()
        {
            if (!_isCanMove)
            {
                _isDragging = false;
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
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
                _lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
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