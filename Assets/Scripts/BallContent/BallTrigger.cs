using System;
using UnityEngine;

namespace BallContent
{
    public class BallTrigger : MonoBehaviour
    {
        public event Action<Portal> TouchedPortal;
        
        public event Action<Hole> TouchedHole;

        public event Action Revert;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Hole hole))
            {
                TouchedHole?.Invoke(hole);
            }

            if (other.TryGetComponent(out Portal portal))
            {
                TouchedPortal?.Invoke(portal);
            }
            
            if (other.TryGetComponent(out Enemy enemy))
            {
                Revert?.Invoke();
            }
        }
    }
}
