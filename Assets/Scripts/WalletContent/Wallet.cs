using System;
using System.Collections;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    private int _defaultValue = 0;
    
    public event Action<int> CoinChanged;
    
    public int Coin { get;private set; }

    public int Star { get;private set; }
    
    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", _defaultValue);
    }

    public void IncreaseCoin(int value)
    {
        if (value <= 0) return;

        StartCoroutine(SmoothChangeCoin(Coin, Coin + value, 1.0f));
        
        Coin += value;
        PlayerPrefs.SetInt("Coin", Coin);
        // CoinChanged?.Invoke(Coin);
    }

    public void DecreaseCoin(int value)
    {
        if (value <= 0) return;
        
        StartCoroutine(SmoothChangeCoin(Coin, Coin - value, 1.0f));
        _audioSource.PlayOneShot(_audioSource.clip);
        Coin -= value;
        PlayerPrefs.SetInt("Coin", Coin);
        // CoinChanged?.Invoke(Coin);
    }
    
    private IEnumerator SmoothChangeCoin(int startValue, int endValue, float duration)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            Coin = Mathf.RoundToInt(Mathf.Lerp(startValue, endValue, elapsed / duration));
            CoinChanged?.Invoke(Coin);
            yield return null;
        }

        Coin = endValue;
        CoinChanged?.Invoke(Coin);
    }
}