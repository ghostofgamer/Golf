using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _victoryScreen;

    private int _defaultIndex = 0;
    
    private void OnEnable()
    {
        _ball.HoleCompleted += Open;
    }

    private void OnDisable()
    {
        _ball.HoleCompleted -= Open;
    }

    public void Init(Ball ball)
    {
        _ball = ball;
        _ball.HoleCompleted += Open;
    }
    
    private void Open()
    {
        int currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel",_defaultIndex);
        int index = PlayerPrefs.GetInt("LevelCompleted", _defaultIndex);

        if (currentLevelIndex >= index)
        {
            int nextLevelIndex = currentLevelIndex + 1;
            PlayerPrefs.SetInt("LevelCompleted", nextLevelIndex);
            Debug.Log("SaveLevel " + nextLevelIndex);
        }
        
        _victoryScreen.SetActive(true);
        Time.timeScale = 0;
    }
}