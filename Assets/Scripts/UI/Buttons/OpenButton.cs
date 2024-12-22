using UnityEngine;

public class OpenButton : AbstractButton
{
    [SerializeField] private GameObject _screen;

    protected override void OnClick() => _screen.SetActive(true);
}