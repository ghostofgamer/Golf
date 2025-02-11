using System;
using UnityEngine;

namespace BallContent
{
    [RequireComponent(typeof(BallMover),typeof(LineRenderer))]
    public class BallDragger : MonoBehaviour
    {
        [SerializeField]private Stick _stick;
        
        private LineRenderer _lr;
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
        
        public event Action<Vector2> EndDragBall;

        private void Awake()
        {
            _ballInput = GetComponentInChildren<BallInput>();
            _ballMover = GetComponent<BallMover>();
            _lr = GetComponent<LineRenderer>();
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

        private void Start()
        {
            _lr.positionCount = 2;
            _lr.enabled = false;
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
            startPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            _isDragging = true;
        }
        
        private void ContinueDrag(Vector3 mouseCurrentPosition)
        {
            if (_isDragging)
            {
                Vector3 mousePosition = mouseCurrentPosition;
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
                float normalizedDragDistance = Mathf.Clamp01(direction.magnitude / maxDragDistance);
                _stick.Dragging(transform.position,normalizedDragDistance,direction);
            }
        }
        
        private void EndDrag()
        {
            if (_isDragging)
            {
                _isDragging = false;
                _lr.enabled = false;
                _lr.SetPosition(0, Vector3.zero);
                _lr.SetPosition(1, Vector3.zero);
                Vector2 direction = startPoint - endPoint;
                EndDragBall?.Invoke(direction);
                StepDone?.Invoke();
                _stick.ReturnDefaultLocalEuler();
            }
        }
    }
}
