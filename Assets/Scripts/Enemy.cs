using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;

    private Vector3 _startPosition;
    
    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    private void Update()
    {
        if (_ball != null)
        {
            if (IsBallWithinBounds(_ball.localPosition))
            {
                Vector2 direction = _ball.position - transform.position;
                direction.Normalize();
                transform.position = Vector2.MoveTowards(transform.position, _ball.position, _speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            transform.localPosition = _startPosition;
            ball.Revert();
        }
    }

    private bool IsBallWithinBounds(Vector2 ballPosition)
    {
        return ballPosition.x >= _minX && ballPosition.x <= _maxX &&
               ballPosition.y >= _minY && ballPosition.y <= _maxY;
    }
}