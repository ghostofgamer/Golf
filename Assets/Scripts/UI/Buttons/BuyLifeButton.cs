using UnityEngine;

namespace UI.Buttons
{
    public class BuyLifeButton : AbstractButton
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField]private LifeCounter _lifeCounter;

        private int _price = 100;


        protected override void OnClick()
        {
            base.OnClick();
        
            if (_wallet.Coin < _price) return;
        
            _lifeCounter.IncreaseLife();
            _wallet.DecreaseCoin(_price);
        }
    }
}
