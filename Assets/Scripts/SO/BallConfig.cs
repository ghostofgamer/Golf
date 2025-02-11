using BallContent;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "BallConfig",menuName = "SO/BallConfig", order = 1)]
    public class BallConfig : ScriptableObject
    {
        /*[SerializeField] private BallDragger _ballDragger;
    [SerializeField] private BallHole _ballHole;
    [SerializeField]private BallMover _ballMover;*/
    
        [field:SerializeField]public BallDragger BallDragger { get; private set; }
    }
}
