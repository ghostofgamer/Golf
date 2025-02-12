using UnityEngine;

namespace Singletons
{
    public class SoundGamePlayer : MonoBehaviour
    {
        [SerializeField]private AudioSource _audioSource;
        [SerializeField]private AudioClip _buttonClickSound;
    
        public static SoundGamePlayer Instance { get; private set; }
    
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayButtonClickSound()
        {
            _audioSource.PlayOneShot(_buttonClickSound);
        }
    }
}
