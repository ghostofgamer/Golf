using UnityEngine;

[CreateAssetMenu(fileName = "LevelStarsConfig", menuName = "Configs/LevelStarsConfig", order = 1)]
public class SOLevelStarsConfig : ScriptableObject
{
 [SerializeField] private int _threeStarSteps;
 [SerializeField] private int _twoStarSteps;
 [SerializeField] private int _oneStarSteps;
 
 public int ThreeStarSteps => _threeStarSteps;
 public int TwoStarSteps => _twoStarSteps;
 public int OneStarSteps => _oneStarSteps;
}