using TMPro;
using UnityEngine;

public class WalletViewer : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _valueText;

    private void OnEnable()
    {
        ChangeValue(_wallet.Coin);
        _wallet.CoinChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _wallet.CoinChanged -= ChangeValue;
    }

    private void ChangeValue(int value)
    {
        _valueText.text = value.ToString();
    }
}