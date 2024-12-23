using UnityEngine;

public class StepCounter : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    public int StepsCount;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        _ball.StepDone -= IncreaseStep;
    }

    private void Start()
    {
        
    }

    public void Init(Ball ball)
    {
        _ball = ball;
        _ball.StepDone += IncreaseStep;
    }

    private void IncreaseStep()
    {
        StepsCount++;
    }
}
