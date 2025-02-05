using UnityEngine;

public class SelectStickButton : AbstractButton
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private int _index;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject _priceContent;
    [SerializeField] private int _price;

    private bool _isPurchased;
    private int _buyIndex = 1;

    protected override void OnClick()
    {
        if (!_isPurchased)
            Buy();
        else
            Select();
    }

    public void CheckPurchase()
    {
        int index = PlayerPrefs.GetInt("StickPurchase" + _index, 0);
        
        if (index <= 0 && _price > 0) return;


        _isPurchased = true;
        _priceContent.SetActive(false);
    }

    private void Select()
    {
        PlayerPrefs.SetInt("StickIndex", _index);
    }

    private void Buy()
    {
        if (_wallet.Coin < _price) return;
        
        _effect.Play();
        PlayerPrefs.SetInt("StickPurchase" + _index, _buyIndex);
        PlayerPrefs.SetInt("StickIndex", _index);
        _isPurchased = true;
        _priceContent.SetActive(false);
        _wallet.DecreaseCoin(_price);
    }
}
