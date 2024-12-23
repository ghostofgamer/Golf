using TMPro;
using UnityEngine;

public class StarViewer : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _valueText;
    
    private void Start()
    {
        ChangeValue(_wallet.Star);
    }

    private void OnEnable()
    {
        ChangeValue(_wallet.Star);
        _wallet.StarChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _wallet.StarChanged -= ChangeValue;
    }

    private void ChangeValue(int value)
    {
        _valueText.text = value.ToString();
    }
}
