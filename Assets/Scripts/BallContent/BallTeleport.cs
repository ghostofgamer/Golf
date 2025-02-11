using System.Collections;
using UnityEngine;

namespace BallContent
{
    [RequireComponent(typeof(BallTrigger))]
    public class BallTeleport : MonoBehaviour
    {
        [SerializeField]private float _teleportDelay = 0.1f;

        private BallTrigger _ballTrigger;
        private bool _justTeleported = true;
        
        private void Awake()
        {
            _ballTrigger = GetComponent<BallTrigger>();
        }

        private void OnEnable()
        {
            _ballTrigger.TouchedPortal += Teleportation;
        }

        private void OnDisable()
        {
            _ballTrigger.TouchedPortal -= Teleportation;
        }

        private void Teleportation(Portal portal)
        {
            if (_justTeleported)
            {
                _justTeleported = false;
                transform.position = portal.PortalObject.transform.position;
            }
            else
                StartCoroutine(Teleport());
        }
        
        private IEnumerator Teleport()
        {
            yield return new WaitForSeconds(_teleportDelay);
            _justTeleported = true;
        }
    }
}
