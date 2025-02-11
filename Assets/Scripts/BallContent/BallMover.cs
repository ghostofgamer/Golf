using System;
using System.Collections;
using UnityEngine;

namespace BallContent
{
    [RequireComponent(typeof(BallDragger), typeof(Rigidbody2D), typeof(BallHole))]
    public class BallMover : MonoBehaviour
    {
        [SerializeField] private Stick _stick;

        private Rigidbody2D _rb;
        private BallHole _ballHole;
        private BallDragger _ballDragger;

        float maxX = 0.06f;
        float minX = -0.06f;
        float maxY = 0.06f;
        float minY = -0.06f;
        
        public event Action StopedBall;

        public bool IsMoving { get; private set; }

        private void Awake()
        {
            _ballDragger = GetComponent<BallDragger>();
            _ballHole = GetComponent<BallHole>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _ballDragger.EndDragBall += StartMove;
            IsMoving = false;
            _stick.SetValue(true);
        }

        private void OnDisable()
        {
            _ballDragger.EndDragBall -= StartMove;
        }

        private void Start()
        {
            StopedBall?.Invoke();
            _stick.SetValue(true);
        }

        public void StartMove(Vector2 direction)
        {
            IsMoving = true;

            direction.x = Mathf.Clamp(direction.x, minX, maxX);
            direction.y = Mathf.Clamp(direction.y, minY, maxY);
            _rb.AddForce(direction * 10000f);

            StartCoroutine(MoveChecker());
        }

        private IEnumerator MoveChecker()
        {
            yield return new WaitForSeconds(1f);

            while (IsMoving)
            {
                if (_rb.velocity.magnitude > 0.01f && _stick.gameObject.activeSelf)
                {
                    _stick.SetValue(false);
                }
                else if (_rb.velocity.magnitude < 0.01f)
                {
                    if (_ballHole.IsInHole) yield break;

                    StopedBall?.Invoke();
                    IsMoving = false;
                    _stick.SetValue(true);
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
    }
}