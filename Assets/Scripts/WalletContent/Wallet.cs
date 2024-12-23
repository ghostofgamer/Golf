using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _defaultValue = 0;

    public event Action<int> CoinChanged;
    public event Action<int> StarChanged;
    
    public int Coin { get;private set; }

    public int Star { get;private set; }
    
    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", _defaultValue);
        Star = PlayerPrefs.GetInt("Star", _defaultValue);
            Debug.Log("ЗВЕЗД " + Star);
    }

    public void IncreaseCoin(int value)
    {
        if (value <= 0) return;

        Coin += value;
        PlayerPrefs.SetInt("Coin", Coin);
        CoinChanged?.Invoke(Coin);
    }

    public void DecreaseCoin(int value)
    {
        if (value <= 0) return;

        Coin -= value;
        PlayerPrefs.SetInt("Coin", Coin);
        CoinChanged?.Invoke(Coin);
    }

    public void IncreaseStar(int value)
    {
        if (value <= 0) return;

        Star += value;
        PlayerPrefs.SetInt("Star", Star);
        StarChanged?.Invoke(Star);
    }

    public void DecreaseStar(int value)
    {
        if (value <= 0) return;

        Star -= value;
        PlayerPrefs.SetInt("Star", Star);
        StarChanged?.Invoke(Star);
    }
}