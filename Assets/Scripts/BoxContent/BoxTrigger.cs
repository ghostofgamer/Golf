using System;
using System.Net.Http.Headers;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    [SerializeField]private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _boxDamaged;
    [SerializeField] private Sprite _ships;
    [SerializeField]private BoxCollider2D _boxCollider;

    private int _currentHits = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out Ball ball))
        {
            _currentHits++;

            if (_currentHits is 1 and < 2)
                _boxDamaged.SetActive(true);

            if (_currentHits >= 2)
            {
                _boxDamaged.SetActive(false);
                _boxCollider.enabled = false;
                _spriteRenderer.sprite = _ships;
                // gameObject.SetActive(false);
            }
                
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            _currentHits++;

            if (_currentHits is 1 and < 2)
                _boxDamaged.SetActive(true);

            if (_currentHits >= 2)
                gameObject.SetActive(false);
        }
    }
}