using UnityEngine;

namespace Singletons
{
    public class SoundGamePlayer : MonoBehaviour
    {
        [SerializeField]private AudioSource _audioSource;
        [SerializeField]private AudioClip _buttonClickSound;
        [SerializeField]private AudioClip _hitBallSound;
        [SerializeField]private AudioClip _teleportationSound;
        
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

        public void PlayHitBall()
        {
            _audioSource.PlayOneShot(_hitBallSound);
        }

        public void TeleportationBall()
        {
            _audioSource.PlayOneShot(_teleportationSound);
        }

        public void PlaySound(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}
