using UnityEngine;
using UnityEngine.Serialization;

public class SpriteInventory : MonoBehaviour
{
    [SerializeField] private Sprite[] _ballSprites;
    [SerializeField] private Sprite[] _backgroundsSprites;
    [SerializeField] private Sprite[] _stickSprites;

    public Sprite GetBallSprite(int index)
    {
        return _ballSprites[index];
    }

    public Sprite GetBackgroundSprite(int index)
    {
        return _backgroundsSprites[index];
    }

    public Sprite GetStickSprite(int index)
    {
        return _stickSprites[index];
    }
}