using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    private Vector2 startPointNew ;
    private Vector2 endPoint;
    public float maxDragDistance = 2f;

    public event Action HoleCompleted;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lr.positionCount = 2;
        _lr.enabled = false;
    }

    
    void Update()
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
        Debug.Log(_rb.velocity.magnitude);
        
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
            HoleCompleted?.Invoke();
            gameObject.SetActive(false);
        }
    }

    void StartDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane; // Установите z-координату для правильного преобразования
        startPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        // Debug.Log("Start Drag at: " + startPoint);
        
        
        
        // startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _isDragging = true;
        // _lr.enabled = true;
    }

    void ContinueDrag()
    {
        if (_isDragging)
        {
           
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane; // Установите z-координату для правильного преобразования
            endPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            // Debug.Log("Continue Drag at: " + endPoint);
            
            
            // endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = startPoint - endPoint;
            
            if (direction.magnitude > maxDragDistance)
            {
                // Debug.Log("Большеg");
                direction = direction.normalized * maxDragDistance;
            }
             _lr.enabled = true;
            _lr.SetPosition(0, transform.position);
            // _lr.SetPosition(1, startPoint - direction);
            _lr.SetPosition(1, startPointNew + direction*5f);
        }
    }

    void EndDrag()
    {
        // Debug.Log("_isDraggingEND   NOW ");
        if (_isDragging)
        {
            _isDragging = false;
            _lr.enabled = false;
            
            _lr.SetPosition(0, Vector3.zero);
            _lr.SetPosition(1, Vector3.zero);
            
            Vector2 direction = startPoint - endPoint;
            // Debug.Log("_isDraggingEND " + direction);


            /*if (direction != Vector2.zero)
            {
                // Используем DOTween для анимации движения мяча
                Vector2 targetPosition = (Vector2)transform.position + direction.normalized * direction.magnitude * 10f;
                transform.DOMove(targetPosition, 1f).SetEase(Ease.Linear);
            }
            else
            {
                Debug.LogWarning("Direction is zero vector!");
            }*/
            
            
            _rb.AddForce(direction * 10000f);
        }
    }
    
    /*private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
       
        Vector2 inputpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(transform.position, inputpos);

         Debug.Log("PlayerInput " + distance);
        
        if (Input.GetMouseButtonDown(0) && distance <= 0.5f)
            DragStart();

        if (Input.GetMouseButton(0) && _isDragging)
            DragChange();

        if (Input.GetMouseButtonUp(0) && _isDragging)
            DragRelease(inputpos);
    }

    private void DragStart()
    {
        Debug.Log("DragStart");
        _isDragging = true;
    }

    private void DragChange()
    {
    }

    private void DragRelease(Vector2 pos)
    {
        Debug.Log("DragRelease");
        float distance = Vector2.Distance((Vector2)transform.position, pos);
        _isDragging = false;

        if (distance < 1f)
        {
            return;
        }
        
        Vector2 dir = (Vector2)transform.position - pos;
        _rb.velocity = Vector2.ClampMagnitude(dir*_power, _maxPower);
    }*/
}