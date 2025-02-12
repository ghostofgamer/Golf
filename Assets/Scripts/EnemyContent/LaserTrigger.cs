using System;
using BallContent;
using Interfaces;
using Singletons;
using UnityEngine;

namespace EnemyContent
{
    public class LaserTrigger : MonoBehaviour, ILoseTrigger
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            /*if(other.TryGetComponent(out Ball ball))
               SoundGamePlayer.Instance */
        }
    }
}