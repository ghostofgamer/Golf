using System;
using UnityEngine;

namespace BallContent
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Collider2D _shadowCollider;
        
        // public event Action Died;
        
        /*public void Die()
        {
            gameObject.SetActive(false);
        }*/

        /*public void Revert()
        {
            // Died?.Invoke();
        }*/
    }
}