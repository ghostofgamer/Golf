using UnityEngine;
using UnityEngine.Serialization;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _startBallPosition;
    [SerializeField] private Ball _ball;
    [FormerlySerializedAs("_starsConfig")] [SerializeField] private SOLevelConfig config;

    public SOLevelConfig Config => config;

    public Transform StartBallPosition => _startBallPosition;

    public Ball Ball => _ball;
}