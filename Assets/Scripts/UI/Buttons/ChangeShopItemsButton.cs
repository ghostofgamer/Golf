using System.Collections;
using System.Collections.Generic;
using UI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeShopItemsButton : AbstractButton
{
    [SerializeField] private int _index;
    [FormerlySerializedAs("_shop")] [SerializeField] private ShopScreen shopScreen;
    
    protected override void OnClick()
    {
        shopScreen.ChangeShopItems(_index);
    }
}
