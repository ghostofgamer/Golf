using System.Collections;
using UnityEngine;

namespace BallContent
{
    public class BallReturner : MonoBehaviour
    {
        private BallTrigger _ballTrigger;
        private Vector3 _startPosition;

        private void OnDisable()
        {
            _ballTrigger.Revert -= RevertPosition;
        }
        
        public void Init(BallTrigger ballTrigger)
        {
            _ballTrigger = ballTrigger;
            _startPosition = _ballTrigger.transform.localPosition;
            _ballTrigger.Revert += RevertPosition;
        }

        private void RevertPosition()
        {
            StartCoroutine(TransformStartPosition());
        }
        
    
        private IEnumerator TransformStartPosition()
        {
            _ballTrigger.gameObject.SetActive(false);
            _ballTrigger.transform.localPosition = _startPosition;
            yield return new WaitForSeconds(0.5f);
            _ballTrigger.gameObject.SetActive(true);
        }
    }
}