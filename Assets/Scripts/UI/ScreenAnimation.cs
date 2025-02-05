using DG.Tweening;
using UnityEngine;

public class ScreenAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _screen;
    [SerializeField] private float animationDuration = 1.0f;
    private Vector2 offScreenPosition;
    private Vector2 onScreenPosition;
    
    private void OnEnable()
    {
        offScreenPosition = new Vector2(0, -Screen.height*3);
        onScreenPosition = new Vector2(0, 0);
        _screen.anchoredPosition = offScreenPosition;
        ShowShopScreen();
    }
    
    private void ShowShopScreen()
    {
        _screen.DOAnchorPos(onScreenPosition, animationDuration);
    }
}
