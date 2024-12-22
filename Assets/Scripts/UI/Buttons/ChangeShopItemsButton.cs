using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShopItemsButton : AbstractButton
{
    [SerializeField] private int _index;
    [SerializeField] private Shop _shop;
    
    protected override void OnClick()
    {
        _shop.ChangeShopItems(_index);
    }
}
