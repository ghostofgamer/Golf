using System;
using UnityEngine;
using UnityEngine.Serialization;

public class LifeCounter : MonoBehaviour
{
    private int _defaultValue = 5;

    public event Action<int> LifeValueChanged;
    
    public int CurrentLifeCount{get; private set;}

    private void Awake()
    {
        CurrentLifeCount = PlayerPrefs.GetInt("Life", _defaultValue);
    }

    public void IncreaseLife()
    {
        CurrentLifeCount++;
        PlayerPrefs.SetInt("Life", CurrentLifeCount);
        LifeValueChanged?.Invoke(CurrentLifeCount);
    }

    public void DecreaseCoin()
    {
        CurrentLifeCount--;
        
        if (CurrentLifeCount < 0)
            CurrentLifeCount = 0;
        
        PlayerPrefs.SetInt("Life", CurrentLifeCount);
        LifeValueChanged?.Invoke(CurrentLifeCount);
    }
}