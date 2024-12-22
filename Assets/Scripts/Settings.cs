using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private int _soundIndex;
    private int _defaultSoundValue = 1;

    private void Start()
    {
        InitSound();
    }

    private void InitSound()
    {
        _soundIndex = PlayerPrefs.GetInt("Sound", _defaultSoundValue);
        AudioListener.volume = _soundIndex;

        if (_soundImage != null)
            _soundImage.sprite = _soundIndex == _defaultSoundValue ? _soundOn : _soundOff;
    }

    public void ChangeSound()
    {
        _soundIndex = PlayerPrefs.GetInt("Sound", _defaultSoundValue);
        _soundIndex = _defaultSoundValue - _soundIndex;
        AudioListener.volume = _soundIndex;
        PlayerPrefs.SetInt("Sound", _soundIndex);
        _soundImage.sprite = _soundIndex == _defaultSoundValue ? _soundOn : _soundOff;
    }
}