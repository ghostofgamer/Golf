using BallContent;
using DG.Tweening;
using UnityEngine;

namespace UI.Screens
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private StepCounter _stepCounter;
        [SerializeField] private LifeCounter _lifeCounter;
        [SerializeField] private GameObject _loseScreen;
        [SerializeField] private RectTransform loseScreen;
        [SerializeField] private float animationDuration = 1.0f;
        [SerializeField] private Ease animationEase = Ease.Linear ;

        private bool _isOpened = false;
        private BallHole _ballHole;
        private Vector2 offScreenPosition;
        private Vector2 onScreenPosition;
        private BallTrigger _ballTrigger;
    
        private void OnEnable()
        {
            _stepCounter.StepsOver += Open;
        }

        private void OnDisable()
        {
            _stepCounter.StepsOver -= Open;
            _ballTrigger.Lose -= Open;
        }

        private void Start()
        {
            offScreenPosition = new Vector2(0, -Screen.height);
            onScreenPosition = new Vector2(0, 0);
            loseScreen.anchoredPosition = offScreenPosition;
        }

        public void Init(BallTrigger ballTrigger)
        {
            _ballTrigger = ballTrigger;
            _ballTrigger.Lose += Open;
        }
    
        private void Open()
        {
            if (_isOpened) return;

            _isOpened = true;
            _lifeCounter.DecreaseCoin();
            _loseScreen.SetActive(true);
            ShowLoseScreen();
            // Time.timeScale = 0;
        }
    
        private void ShowLoseScreen()
        {
            loseScreen.DOAnchorPos(onScreenPosition, animationDuration);
        }
    }
}