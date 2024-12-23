using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private Level _level;
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private StepCounter _stepCounter;
    [SerializeField] private Wallet _wallet;

    private int _defaultIndex = 0;
    private int _starsCount = 0;

    private void OnEnable()
    {
        _ball.HoleCompleted += Open;
    }

    private void OnDisable()
    {
        _ball.HoleCompleted -= Open;
    }

    public void Init(Ball ball, Level level)
    {
        _ball = ball;
        _ball.HoleCompleted += Open;
        _level = level;
    }

    private void Open()
    {
        int currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", _defaultIndex);
        int index = PlayerPrefs.GetInt("LevelCompleted", _defaultIndex);

        if (currentLevelIndex >= index)
        {
            int nextLevelIndex = currentLevelIndex + 1;
            PlayerPrefs.SetInt("LevelCompleted", nextLevelIndex);
            Debug.Log("SaveLevel " + nextLevelIndex);
        }

        _victoryScreen.SetActive(true);
        ShowStar();
        Time.timeScale = 0;
    }

    private void ShowStar()
    {
        if (_stepCounter.StepsCount <= _level.StarsConfig.ThreeStarSteps)
            _starsCount = 3;
        else if (_stepCounter.StepsCount <= _level.StarsConfig.TwoStarSteps)
            _starsCount = 2;
        else if (_stepCounter.StepsCount <= _level.StarsConfig.OneStarSteps)
            _starsCount = 1;
        else
            _starsCount = 0;

        /*int starCount = PlayerPrefs.GetInt("Star", 0);
        starCount += _starsCount;
        PlayerPrefs.SetInt("Star", starCount);*/
        _wallet.IncreaseStar(_starsCount);
        /*
        Debug.Log("Скок звезд 3 надо  " + _level.StarsConfig.ThreeStarSteps);
        Debug.Log("Скок звезд  2 надо " + _level.StarsConfig.TwoStarSteps);
        Debug.Log("Скок звезд    1 надо " + _level.StarsConfig.OneStarSteps);
        Debug.Log("Скок звезд " + _starsCount);
        Debug.Log("шагов " + _stepCounter.StepsCount);*/

        for (int i = 0; i < _starsCount; i++)
            _stars[i].SetActive(true);
    }
}