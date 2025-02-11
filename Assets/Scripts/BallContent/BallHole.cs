using System;
using System.Collections;
using UnityEngine;

namespace BallContent
{
    public class BallHole : MonoBehaviour
    {
        [SerializeField] private float moveDuration = 1.0f;
        
        private BallTrigger _ballTrigger;
        private bool _isInHole = false;
        
        public event Action HoleCompleted;
        
        private void Awake()
        {
            _ballTrigger = GetComponent<BallTrigger>();
        }

        private void OnEnable()
        {
            _ballTrigger.TouchedHole += RollInHoll;
        }

        private void OnDisable()
        {
            _ballTrigger.TouchedHole -= RollInHoll;
        }
        
        private void RollInHoll(Hole hole)
        {
            _isInHole = true;
            HoleCompleted?.Invoke();
            StartCoroutine(ShrinkAndMove(hole));
        }
        
        private IEnumerator ShrinkAndMove(Hole hole)
        {
            Vector3 initialScale = transform.localScale;
            Vector3 initialPosition = transform.position;
            Vector3 targetPosition = hole.Center.position;
            targetPosition.y -= 0.15f;
        
            float elapsedTime = 0f;

            while (elapsedTime < moveDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / moveDuration;
                transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
                transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);
                yield return null;
            }
        
            hole.transform.position = targetPosition;
            hole.transform.localScale = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}