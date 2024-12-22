using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _victoryScreen;

    private void OnEnable()
    {
        _ball.HoleCompleted += Open;
    }

    private void OnDisable()
    {
        _ball.HoleCompleted -= Open;
    }

    private void Open()
    {
        _victoryScreen.SetActive(true);
        Time.timeScale = 0;
    }
}