using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject[] _shopItems;

    private void OnEnable()
    {
        OpenShopItems(0);
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
}