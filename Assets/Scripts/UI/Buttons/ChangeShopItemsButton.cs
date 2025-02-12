using UI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Buttons
{
    public class ChangeShopItemsButton : AbstractButton
    {
        [SerializeField] private int _index;
        [FormerlySerializedAs("_shop")] [SerializeField] private ShopScreen shopScreen;
    
        protected override void OnClick()
        {
            base.OnClick();
            shopScreen.ChangeShopItems(_index);
        }
    }
}
