using UnityEngine;

namespace BallContent
{
    public class BallDisabler : MonoBehaviour
    {
        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
