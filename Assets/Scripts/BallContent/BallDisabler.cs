using UnityEngine;

namespace BallContent
{
    public class BallDisabler : MonoBehaviour
    {
        private BallTrigger _ballTrigger;

        private void Awake()
        {
            _ballTrigger = GetComponent<BallTrigger>();
        }

        private void OnEnable()
        {
            _ballTrigger.Lose += Disable;
        }

        private void OnDisable()
        {
            _ballTrigger.Lose -= Disable;
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
