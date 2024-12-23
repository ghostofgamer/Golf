using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _startBallPosition;
    [SerializeField] private Ball _ball;
    [SerializeField] private SOLevelStarsConfig _starsConfig;

    public SOLevelStarsConfig StarsConfig => _starsConfig;

    public Transform StartBallPosition => _startBallPosition;

    public Ball Ball => _ball;
}