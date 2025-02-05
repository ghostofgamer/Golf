using UnityEngine;

namespace UI.Screens
{
    public class ShopScreen : AbstractScreen
    {
        [SerializeField] private GameObject[] _shopItems;
        [SerializeField] private SelectSpriteBallButton[] _selectSpriteBallButton;
        [SerializeField] private SelectBackGroundButton[] _selectBackGroundButtons;
        [SerializeField] private SelectStickButton[] _selectStickButtons;

        /*private void OnEnable()
    {
        OpenShopItems(0);
        CheckPurchased();
    }*/

        public override void OpenScreen()
        {
            base.OpenScreen();
            OpenShopItems(0);
            CheckPurchased();
        }

        public void ChangeShopItems(int index)
        {
            OpenShopItems(index);
        }

        private void OpenShopItems(int index)
        {
            foreach (var shopitem in _shopItems)
                shopitem.SetActive(false);

            _shopItems[index].SetActive(true);
        }

        private void CheckPurchased()
        {
            foreach (var selectSpriteButton in _selectSpriteBallButton)
                selectSpriteButton.CheckPurchase();

            foreach (var selectSpriteButton in _selectBackGroundButtons)
                selectSpriteButton.CheckPurchase();

            foreach (var selectSpriteButton in _selectStickButtons)
                selectSpriteButton.CheckPurchase();
        }
    }
}