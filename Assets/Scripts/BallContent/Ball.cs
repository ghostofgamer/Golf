using System;
using System.Collections;
using UnityEngine;

namespace BallContent
{
    public class Ball : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField] private LineRenderer _lr;
        [SerializeField] private CircleCollider2D _colliderBall;

        [Header("Atributes")] [SerializeField] private float _maxPower = 10f;
        [SerializeField] private float _power = 3f;
        [SerializeField] private float _maxGoalSpeed = 4f;
        [SerializeField] private float moveDuration = 1.0f;

        [SerializeField] private Collider2D _shadowCollider;


        private float maxRotationAngle = 45f;
        public Transform clubTransform;

        float maxX = 0.06f;
        float minX = -0.06f;
        float maxY = 0.06f;
        float minY = -0.06f;

        private bool _isDragging;
        private bool _inHole;
        public bool _isMoving;
        private Vector2 startPoint;
        private Vector2 startPointNew;
        private Vector2 endPoint;
        public float maxDragDistance = 2f;
        private float stopTimeThreshold = 0.5f;
        private float stopTimeElapsed = 0f;
        private bool justTeleported = true;
        private bool _isInHole = false;
        public float raycastDistance = 5f;
        public LayerMask layerMask;

        public float clubDistanceFromBall = 1.0f;
        public float maxSwingAngle = 90f;


        public event Action HoleCompleted;

        public event Action StepDone;

        public event Action StopedBall;

        public event Action StartDragBall;

        public event Action Died;

        public bool IsMoving => _isMoving;

        private void OnEnable()
        {
            StopedBall?.Invoke();
            _isMoving = false;
            clubTransform.gameObject.SetActive(true);
        }

        private void Start()
        {
            StopedBall?.Invoke();
            // _shadowCollider.enabled = true;


            _rb = GetComponent<Rigidbody2D>();
            _lr.positionCount = 2;
            _lr.enabled = false;
            clubTransform.gameObject.SetActive(true);
        }

        void OnMouseDown()
        {
            StartDrag();
        }

        void OnMouseDrag()
        {
            ContinueDrag();
        }

        void OnMouseUp()
        {
            EndDrag();
        }

        private void Update()
        {
            startPointNew = transform.position;
        }

        private void StartDrag()
        {
            if (_isMoving) return;

            StartDragBall?.Invoke();
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            Collider2D ballCollider = GetComponent<Collider2D>();


            startPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            _isDragging = true;
        }

        private void ContinueDrag()
        {
            if (_isDragging)
            {
                Vector3 mousePosition = Input.mousePosition;
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
                // float rotationZ = t * maxSwingAngle;

                float maxRotationAngle = 45f; // Максимальный угол поворота
                float accelerationFactor = 15f; // Коэффициент ускорения
                float rotationZ = t * maxRotationAngle * accelerationFactor;

                Vector2 toBall = transform.position - clubTransform.position;
                float angle = Mathf.Atan2(toBall.y, toBall.x) * Mathf.Rad2Deg;

                clubTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - rotationZ));
                // clubTransform.localEulerAngles = new Vector3(0, 0, rotationZ);

                Vector3 ballPosition = transform.position;
                // Vector3 clubOffset = new Vector3(-direction.x, -direction.y, 0).normalized * 0.5f;
                Vector3 clubOffset = new Vector3(-direction.x, -direction.y, 0).normalized * clubDistanceFromBall;
                clubTransform.position = ballPosition + clubOffset;

                // clubTransform.LookAt(ballPosition, Vector3.up);
            }
        }

        private void EndDrag()
        {
            if (_isDragging)
            {
                _isMoving = true;
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
                StartCoroutine(MoveChecker());
            }
        }

        private IEnumerator MoveChecker()
        {
            yield return new WaitForSeconds(1f);

            while (_isMoving)
            {
                if (_rb.velocity.magnitude > 0.01f)
                {
                    clubTransform.gameObject.SetActive(false);
                }
                else if (_rb.velocity.magnitude < 0.01f)
                {
                    if (_isInHole) yield break;

                    StopedBall?.Invoke();
                    _isMoving = false;
                    clubTransform.gameObject.SetActive(true);
                    yield break;
                }

                if (_rb.velocity.magnitude < 0.3f)
                {
                    _rb.velocity = Vector2.zero;
                    _rb.angularVelocity = 0f;
                }

                yield return null;
            }
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }

        public void Revert()
        {
            Died?.Invoke();
        }
    }
}