using BallContent;
using UnityEngine;
using UnityEngine.Serialization;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _startBallPosition;
    [SerializeField] private Ball _ball;
    [SerializeField] private BallHole _ballHole;
    [SerializeField] private BallDragger _ballDragger;
    
    [FormerlySerializedAs("_starsConfig")] [SerializeField] private SOLevelConfig config;

    public SOLevelConfig Config => config;

    public Transform StartBallPosition => _startBallPosition;

    public Ball Ball => _ball;
    
    public BallHole BallHole=>_ballHole;
    
    public BallDragger BallDragger=>_ballDragger;

   [field:SerializeField] public BallMover BallMover { get; private set; }
   
   [field:SerializeField] public SpriteRenderer Stick { get; private set; }
   
   [field:SerializeField] public BallDisabler BallDisabler { get; private set; }
   
   [field:SerializeField] public BallTrigger BallTrigger { get; private set; }
}