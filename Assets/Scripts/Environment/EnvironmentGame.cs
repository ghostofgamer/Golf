using System.Collections;
using System.Collections.Generic;
using BallContent;
using Singletons;
using UnityEngine;

public class EnvironmentGame : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Ball>(out _))
        {
            Debug.Log("dsfsdfsdfsdfsdfsdfsf");
            SoundGamePlayer.Instance.PlaySound(_clip);
        }
    }
}