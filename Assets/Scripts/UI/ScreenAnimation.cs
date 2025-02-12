using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class ScreenAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _screen;
        [SerializeField] private float animationDuration = 0.15f;

        private Vector2 offScreenPosition;
        private Vector2 onScreenPosition;

        private void OnEnable()
        {
            offScreenPosition = new Vector2(0, -Screen.height * 1.5f);
            onScreenPosition = new Vector2(0, 0);
            _screen.anchoredPosition = offScreenPosition;
            ShowShopScreen();
        }

        private void ShowShopScreen()
        {
            _screen.DOAnchorPos(onScreenPosition, animationDuration).SetUpdate(true);
        }
    }
}