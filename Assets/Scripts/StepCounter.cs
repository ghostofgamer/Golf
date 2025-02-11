using System;
using BallContent;
using UnityEngine;
using UnityEngine.Serialization;

public class StepCounter : MonoBehaviour
{
    private Ball _ball;
    private BallDragger _ballDragger;
    private BallMover _ballMover;

    private Level _level;

    public event Action<int> MainStepsChanged;

    public event Action StepsOver;

    public int StepsCount { get; private set; }

    public int MaxSteps { get; private set; }

    public int RemainingSteps { get; private set; }

    private void OnDisable()
    {
        // _ball.StepDone -= IncreaseStep;
        _ballDragger.StepDone -= IncreaseStep;
        // _ball.StopedBall -= CheckSteps;
        _ballMover.StopedBall -= CheckSteps;
    }

    public void Init(BallDragger ball,BallMover ballMover, Level level)
    {
        _ballDragger = ball;
        _ballMover=ballMover;
        // _ball.StepDone += IncreaseStep;
        _ballDragger.StepDone += IncreaseStep;
        _ballMover.StopedBall += CheckSteps;
        // _ball.StopedBall += CheckSteps;
        _level = level;
        MaxSteps = _level.Config.MaxStep;
        RemainingSteps = MaxSteps;
        MainStepsChanged?.Invoke(MaxSteps);
    }

    private void IncreaseStep()
    {
        StepsCount++;
        RemainingSteps--;
        MainStepsChanged?.Invoke(RemainingSteps);
    }

    private void CheckSteps()
    {
        if (RemainingSteps <= 0)
        {
            // _ball.Die();
            StepsOver?.Invoke();
        }
    }
}