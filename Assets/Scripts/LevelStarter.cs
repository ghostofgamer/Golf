using System;
using System.Collections;
using BallContent;
using UnityEngine;
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

    private int _defaultIndex = 0;
    private Vector3   _startPosition;
    
    private void Awake()
    {
        Time.timeScale = 1;
        SelectMap();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        _ball.Died -= Transform;
    }

    private void SelectMap()
    {
        int currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", _defaultIndex);

        foreach (var level in _levels)
            level.gameObject.SetActive(false);

        // _startPosition = _levels[currentLevelIndex].StartBallPosition.position;
        _ball = _levels[currentLevelIndex].Ball;
        // _ball.transform.position = _startPosition;
        _ball.gameObject.SetActive(true);
        _startPosition = _ball.transform.localPosition;
        // Debug.Log("START " + _startPosition);
        _ball.Died += Transform;
        
        
        _levels[currentLevelIndex].gameObject.SetActive(true);
        /*_levels[currentLevelIndex].Ball.transform.position = _levels[currentLevelIndex].StartBallPosition.position;
        _levels[currentLevelIndex].Ball.gameObject.SetActive(true);*/
        int indexBallSprite = PlayerPrefs.GetInt("BallSprite", _defaultIndex);
        int indexBackgroundSprite = PlayerPrefs.GetInt("Background", _defaultIndex);
        int indexStickSprite = PlayerPrefs.GetInt("StickIndex", _defaultIndex);
        _levels[currentLevelIndex].Ball.GetComponent<SpriteRenderer>().sprite = _spriteInventory.GetBallSprite(indexBallSprite);
        _levels[currentLevelIndex].Ball.clubTransform.GetComponent<SpriteRenderer>().sprite = _spriteInventory.GetStickSprite(indexStickSprite);
        _backGroundImage.sprite = _spriteInventory.GetBackgroundSprite(indexBackgroundSprite);
        _victoryScreen.Init(_levels[currentLevelIndex].Ball, _levels[currentLevelIndex]);
        // _loseScreen.Init(_levels[currentLevelIndex].Ball);
        _stepCounter.Init(_levels[currentLevelIndex].Ball, _levels[currentLevelIndex]);
    }

    private void Transform()
    {
        StartCoroutine(TransformStartPosition());
    }
    
    private IEnumerator TransformStartPosition()
    {
        Debug.Log("Start Position " + _startPosition);
        _ball.gameObject.SetActive(false);
        _ball.transform.localPosition = _startPosition;
        yield return new WaitForSeconds(0.5f);
        _ball.gameObject.SetActive(true);
        _ball.Died += Transform;
    }
}