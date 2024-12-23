using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField] private LineRenderer _lr;

    [Header("Atributes")] [SerializeField] private float _maxPower = 10f;
    [SerializeField] private float _power = 3f;
    [SerializeField] private float _maxGoalSpeed = 4f;

    private bool _isDragging;
    private bool _inHole;
    private Vector2 startPoint;
    private Vector2 startPointNew;
    private Vector2 endPoint;
    public float maxDragDistance = 2f;

    public event Action HoleCompleted;

    public event Action StepDone;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lr.positionCount = 2;
        _lr.enabled = false;
    }


    private void Update()
    {
        startPointNew = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }

        if (_rb.velocity.magnitude < 0.3f)
        {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Hole>())
        {
            Debug.Log("Попал");
            HoleCompleted?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void StartDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
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

            if (direction.magnitude > maxDragDistance)
                direction = direction.normalized * maxDragDistance;

            _lr.enabled = true;
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1, startPointNew + direction * 5f);
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
            _rb.AddForce(direction * 10000f);
            StepDone?.Invoke();
        }
    }
}