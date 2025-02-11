using System;
using BallContent;
using DG.Tweening;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private StepCounter _stepCounter;
    [SerializeField] private LifeCounter _lifeCounter;
    [SerializeField] private GameObject _loseScreen;
    
    [SerializeField] private RectTransform loseScreen;
    [SerializeField] private float animationDuration = 1.0f;
    [SerializeField] private Ease animationEase = Ease.Linear ;

    private bool _isOpened = false;
    private Ball _ball;
    private Vector2 offScreenPosition;
    private Vector2 onScreenPosition;
    
    private void OnEnable()
    {
        _stepCounter.StepsOver += Open;
    }

    private void OnDisable()
    {
        _stepCounter.StepsOver -= Open;
    }

    private void Start()
    {
        // Начальная позиция за пределами экрана
        offScreenPosition = new Vector2(0, -Screen.height);
        // Конечная позиция в центре экрана
        onScreenPosition = new Vector2(0, 0);
        
        loseScreen.anchoredPosition = offScreenPosition;
    }

    public void Init(Ball ball)
    {
        _ball = ball;
        _ball.HoleCompleted += Open;
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