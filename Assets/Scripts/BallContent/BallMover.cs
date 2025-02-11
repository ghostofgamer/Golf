using System;
using UnityEngine;

namespace BallContent
{
    [RequireComponent(typeof(BallDragger))]
    public class BallMover : MonoBehaviour
    {
        private BallDragger _ballDragger;
    
        public bool IsMoving { get; private set; }

        private void Awake()
        {
            _ballDragger = GetComponent<BallDragger>();
        }

        private void OnEnable()
        {
            _ballDragger.EndDragBall += StartMove;
        }

        private void OnDisable()
        {
            
        }

        public void StartMove()
        {
            IsMoving = true;
        }

        /*private IEnumerator MoveChecker()
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
        }*/
    }
}