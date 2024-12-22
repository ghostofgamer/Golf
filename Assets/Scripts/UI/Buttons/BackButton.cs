using UnityEngine;

public class BackButton : AbstractButton
{
    [SerializeField] private GameObject _screen;
    
    protected override void OnClick()=> _screen.SetActive(false);
}
