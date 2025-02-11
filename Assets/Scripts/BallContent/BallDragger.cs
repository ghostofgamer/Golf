using System;
using UnityEngine;

namespace BallContent
{
    [RequireComponent(typeof(BallInput), typeof(BallMover))]
    public class BallDragger : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lr;
        [SerializeField] private Rigidbody2D _rb;
        
        public Transform clubTransform;
        public float clubDistanceFromBall = 1.0f;
        
        private bool _isDragging;
        private Vector2 startPointNew;
        private Vector2 startPoint;
        private Vector2 endPoint;
        
        float maxX = 0.06f;
        float minX = -0.06f;
        float maxY = 0.06f;
        float minY = -0.06f;
        
        private BallInput _ballInput;
        private BallMover _ballMover;
        
        public float maxDragDistance = 2f;
        
        public event Action StartDragBall;
        
        public event Action StepDone;
        
        public event Action EndDragBall;

        private void Awake()
        {
            _ballInput = GetComponent<BallInput>();
            _ballMover = GetComponent<BallMover>();
        }

        private void OnEnable()
        {
            _ballInput.MouseDownClicked += StartDrag;
            _ballInput.MouseDragged += ContinueDrag;
            _ballInput.MouseUpClicked += EndDrag;
        }

        private void OnDisable()
        {
            _ballInput.MouseDownClicked -= StartDrag;
            _ballInput.MouseDragged -= ContinueDrag;
            _ballInput.MouseUpClicked -= EndDrag;
        }
        
        private void Update()
        {
            startPointNew = transform.position;
        }

        private void StartDrag(Vector3 mouseCurrentPosition)
        {
            if (_ballMover.IsMoving) return;

            StartDragBall?.Invoke();
            Vector3 mousePosition = mouseCurrentPosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            Collider2D ballCollider = GetComponent<Collider2D>();
            
            startPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            _isDragging = true;
        }
        
        private void ContinueDrag(Vector3 mouseCurrentPosition)
        {
            if (_isDragging)
            {
                Vector3 mousePosition = mouseCurrentPosition;
                Debug.Log("фывфывфвфвфвфвф " + mouseCurrentPosition);
                mousePosition.z = Camera.main.nearClipPlane;
                endPoint = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = startPoint - endPoint;
                direction.x = Mathf.Clamp(direction.x, minX, maxX);
                direction.y = Mathf.Clamp(direction.y, minY, maxY);

                if (direction.magnitude > maxDragDistance)
                    direction = direction.normalized * maxDragDistance;

                _lr.enabled = true;
                _lr.SetPosition(0, transform.position);
                _lr.SetPosition(1, startPointNew + direction * 15f);
                float t = Mathf.Clamp01(direction.magnitude / maxDragDistance);
                float maxRotationAngle = 45f; 
                float accelerationFactor = 15f; 
                float rotationZ = t * maxRotationAngle * accelerationFactor;
                Vector2 toBall = transform.position - clubTransform.position;
                float angle = Mathf.Atan2(toBall.y, toBall.x) * Mathf.Rad2Deg;
                clubTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - rotationZ));
                Vector3 ballPosition = transform.position;
                Vector3 clubOffset = new Vector3(-direction.x, -direction.y, 0).normalized * clubDistanceFromBall;
                clubTransform.position = ballPosition + clubOffset;
            }
        }
        
        private void EndDrag()
        {
            if (_isDragging)
            {
                EndDragBall?.Invoke();
                
                // _isMoving = true;
                _isDragging = false;
                _lr.enabled = false;
                _lr.SetPosition(0, Vector3.zero);
                _lr.SetPosition(1, Vector3.zero);
                Vector2 direction = startPoint - endPoint;
                direction.x = Mathf.Clamp(direction.x, minX, maxX);
                direction.y = Mathf.Clamp(direction.y, minY, maxY);
                _rb.AddForce(direction * 10000f);
                StepDone?.Invoke();

                clubTransform.gameObject.SetActive(false);
                clubTransform.localEulerAngles = Vector3.zero;
                // StartCoroutine(MoveChecker());
            }
        }
    }
}
