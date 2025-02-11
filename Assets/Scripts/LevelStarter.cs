using BallContent;
using UI.Screens;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private Level[] _levels;
    [SerializeField] private Ball _ball;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private LoseScreen _loseScreen;
    [SerializeField] private StepCounter _stepCounter;
    [SerializeField]private SpriteInventory _spriteInventory;
    [SerializeField]private Image _backGroundImage;
    [FormerlySerializedAs("ballReverter")] [FormerlySerializedAs("_ballRevert")] [SerializeField]private BallReturner ballReturner;

    private int _defaultIndex = 0;
    private Vector3   _startPosition;
    
    private void Awake()
    {
        Time.timeScale = 1;
        SelectMap();
    }

    private void SelectMap()
    {
        int currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", _defaultIndex);

        foreach (var level in _levels)
            level.gameObject.SetActive(false);

        _ball = _levels[currentLevelIndex].Ball;
        _ball.gameObject.SetActive(true);
        _startPosition = _ball.transform.localPosition;
        _levels[currentLevelIndex].gameObject.SetActive(true);
        int indexBallSprite = PlayerPrefs.GetInt("BallSprite", _defaultIndex);
        int indexBackgroundSprite = PlayerPrefs.GetInt("Background", _defaultIndex);
        int indexStickSprite = PlayerPrefs.GetInt("StickIndex", _defaultIndex);
        ballReturner.Init(_levels[currentLevelIndex].BallTrigger);
        _levels[currentLevelIndex].Ball.GetComponent<SpriteRenderer>().sprite = _spriteInventory.GetBallSprite(indexBallSprite);
        _levels[currentLevelIndex].Stick.sprite = _spriteInventory.GetStickSprite(indexStickSprite);
        _backGroundImage.sprite = _spriteInventory.GetBackgroundSprite(indexBackgroundSprite);
        _victoryScreen.Init(_levels[currentLevelIndex].BallHole, _levels[currentLevelIndex]);
        _stepCounter.Init(_levels[currentLevelIndex].BallDragger,_levels[currentLevelIndex].BallMover, _levels[currentLevelIndex]);
    }
}