using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeViewer : MonoBehaviour
{
    [SerializeField] private LifeCounter _lifeCounter;
    [SerializeField] private TMP_Text _valueText;

    private void OnEnable()
    {
        ChangeValue(_lifeCounter.CurrentLifeCount);
        _lifeCounter.LifeValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _lifeCounter.LifeValueChanged -= ChangeValue;
    }

    private void Start()
    {
        ChangeValue(_lifeCounter.CurrentLifeCount);
    }

    private void ChangeValue(int value)
    {
        _valueText.text = value.ToString();
    }
}
