using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Singletons
{
    public class SoundSettings : MonoBehaviour
    {
        private const string SoundKey = "SoundEnabled";
        private const string SFXKey = "SFXEnabled";

        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private string _volumeParameter = "Music";
        [SerializeField] private string _sfxParameter = "SFX";

        public bool IsSoundOn { get; private set; } = true;
        public bool IsSFXOn { get; private set; } = true;

        private float _valueEnabled = 0f;
        private float _valueDisabled = -80f;

        public static SoundSettings Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("SoundSettings: Settings have been loaded.");
            }
            else
            {
                Debug.Log("SoundSettings: Duplicate instance destroyed.");
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            LoadSettings();
        }

        /*private void Update()
        {
            if (_audioMixerGroup.audioMixer.GetFloat(_volumeParameter, out float soundVolume))
            {
                Debug.Log("SoundSettings: Current Sound Volume: " + soundVolume);
            }
            else
            {
                Debug.LogError("SoundSettings: Failed to get sound volume.");
            }

            if (_audioMixerGroup.audioMixer.GetFloat(_sfxParameter, out float sfxVolume))
            {
                Debug.Log("SoundSettings: Current SFX Volume: " + sfxVolume);
            }
            else
            {
                Debug.LogError("SoundSettings: Failed to get SFX volume.");
            }
        }*/

        public void SetSound(bool enabled)
        {
            if (_audioMixerGroup != null && _audioMixerGroup.audioMixer != null)
            {
                _audioMixerGroup.audioMixer.SetFloat(_volumeParameter, enabled ? _valueEnabled : _valueDisabled);
                Debug.Log("SoundSettings: Sound has been changed to " + enabled);
                IsSoundOn = enabled;
                PlayerPrefs.SetInt(SoundKey, enabled ? 1 : 0);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.LogError("SoundSettings: AudioMixerGroup or AudioMixer is not assigned.");
            }
            
            
            /*_audioMixerGroup.audioMixer.SetFloat(_volumeParameter, enabled ? _valueEnabled : -80);
            Debug.Log("ValueSound " + enabled);
            IsSoundOn = enabled;
            PlayerPrefs.SetInt(SoundKey, enabled ? 1 : 0);
            PlayerPrefs.Save();*/
        }

        public void SetSFX(bool enabled)
        {
            if (_audioMixerGroup != null && _audioMixerGroup.audioMixer != null)
            {
                _audioMixerGroup.audioMixer.SetFloat(_sfxParameter, enabled ? _valueEnabled : _valueDisabled);
                Debug.Log("SoundSettings: SFX has been changed to " + enabled);
                IsSFXOn = enabled;
                PlayerPrefs.SetInt(SFXKey, enabled ? 1 : 0);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.LogError("SoundSettings: AudioMixerGroup or AudioMixer is not assigned.");
            }


            /*_audioMixerGroup.audioMixer.SetFloat(_sfxParameter, enabled ? 0f : -80f);
            Debug.Log("ValueSFX " + enabled);
            IsSFXOn = enabled;
            PlayerPrefs.SetInt(SFXKey, enabled ? 1 : 0);
            PlayerPrefs.Save();*/
        }

        private void LoadSettings()
        {
            IsSoundOn = PlayerPrefs.GetInt(SoundKey, 1) == 1;
            IsSFXOn = PlayerPrefs.GetInt(SFXKey, 1) == 1;

            if (_audioMixerGroup != null && _audioMixerGroup.audioMixer != null)
            {
                _audioMixerGroup.audioMixer.SetFloat(_volumeParameter, IsSoundOn ? _valueEnabled : _valueDisabled);
                _audioMixerGroup.audioMixer.SetFloat(_sfxParameter, IsSFXOn ? _valueEnabled : _valueDisabled);
            }
            else
            {
                Debug.LogError("SoundSettings: AudioMixerGroup or AudioMixer is not assigned.");
            }
        }
    }
}