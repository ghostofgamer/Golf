using System;
using UnityEngine;
using UnityEngine.Serialization;

public class StepCounter : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private Level _level;

    public event Action<int> MainStepsChanged;

    public event Action StepsOver;

    public int StepsCount { get; private set; }

    public int MaxSteps { get; private set; }

    public int RemainingSteps { get; private set; }

    private void OnDisable()
    {
        _ball.StepDone -= IncreaseStep;
        _ball.StopedBall -= CheckSteps;
    }

    public void Init(Ball ball, Level level)
    {
        _ball = ball;
        _ball.StepDone += IncreaseStep;
        _ball.StopedBall += CheckSteps;
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
            _ball.Die();
            StepsOver?.Invoke();
        }
    }
}