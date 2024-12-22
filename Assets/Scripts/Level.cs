using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _startBallPosition;
    [SerializeField] private Ball _ball;
    public Transform StartBallPosition => _startBallPosition;
    public Ball Ball => _ball;
}