using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _defaultCoinValue = 0;

    public event Action<int> CoinChanged;
    
    public int Coin { get;private set; }
    
    private void Start()
    {
        Coin = PlayerPrefs.GetInt("Coin", _defaultCoinValue);
    }

    public void IncreaseCoin(int value)
    {
        if (value <= 0) return;

        Coin += value;
        PlayerPrefs.SetInt("Coin", Coin);
        CoinChanged.Invoke(Coin);
    }

    public void DecreaseCoin(int value)
    {
        if (value <= 0) return;

        Coin -= value;
        PlayerPrefs.SetInt("Coin", Coin);
        CoinChanged.Invoke(Coin);
    }
}