using System;
using TMPro;
using UnityEngine;

public class StepViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _stepText;
    [SerializeField] private StepCounter _stepCounter;

    private void OnEnable()
    {
        _stepCounter.MainStepsChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _stepCounter.MainStepsChanged -= ChangeValue;
    }

    private void Start()
    {
        ChangeValue(_stepCounter.MaxSteps);
    }
    
    private void ChangeValue(int value)
    {
        _stepText.text = value.ToString();
    }
}