using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private Level[] _levels;
    [SerializeField] private Ball _ball;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private StepCounter _stepCounter;

    private int _defaultIndex = 0;

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

        Debug.Log("Куррент " + currentLevelIndex);

        _levels[currentLevelIndex].gameObject.SetActive(true);
        _levels[currentLevelIndex].Ball.transform.position = _levels[currentLevelIndex].StartBallPosition.position;
        _levels[currentLevelIndex].Ball.gameObject.SetActive(true);
        _victoryScreen.Init(_levels[currentLevelIndex].Ball, _levels[currentLevelIndex]);
        _stepCounter.Init(_levels[currentLevelIndex].Ball);


        /*_ball.transform.position = _levels[currentLevelIndex].StartBallPosition.position;
        _ball.gameObject.SetActive(true);*/
    }
}