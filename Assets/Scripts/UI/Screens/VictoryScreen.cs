using System.Collections;
using BallContent;
using DG.Tweening;
using UnityEngine;

namespace UI.Screens
{
    public class VictoryScreen : MonoBehaviour
    {
        [SerializeField]private AudioSource _audioSource;
        [SerializeField] private RectTransform _winScreen;
        [SerializeField] private Ball _ball;
        [SerializeField] private BallHole _ballHole;
        [SerializeField] private GameObject _victoryScreen;
        [SerializeField] private Level _level;
        [SerializeField] private GameObject[] _stars;
        [SerializeField] private StepCounter _stepCounter;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private ParticleSystem[] _effects;
    
        private float _animationDuration = 1f;
        private Vector2 _offScreenPosition;
        private Vector2 _onScreenPosition;
    
        private int _defaultIndex = 0;
        private int _starsCount = 0;
        private bool _isOpened = false;

        private void OnEnable()
        {
            _ballHole.HoleCompleted += Open;
        }

        private void OnDisable()
        {
            _ballHole.HoleCompleted -= Open;
        }

        private void Start()
        {
            _offScreenPosition = new Vector2(0, -Screen.height);
            _onScreenPosition = new Vector2(0, 0);
            _winScreen.anchoredPosition = _offScreenPosition;
        }

        public void Init(BallHole ball, Level level)
        {
            _ballHole = ball;
            _ballHole.HoleCompleted += Open;
            _level = level;
        }

        private void Open()
        {
            if (_isOpened) return;

            _isOpened = true;

            int currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", _defaultIndex);
            int index = PlayerPrefs.GetInt("LevelCompleted", _defaultIndex);

            if (currentLevelIndex >= index)
            {
                int nextLevelIndex = currentLevelIndex + 1;
                PlayerPrefs.SetInt("LevelCompleted", nextLevelIndex);
          
            }

            _victoryScreen.SetActive(true);
            _audioSource.PlayOneShot(_audioSource.clip);
            StartCoroutine(ShowConfetti());
            ShowVictoryScreen();
            ShowStar();
            // Time.timeScale = 0;
        }

        private void ShowStar()
        {
            float percentageCompleted = (float)_stepCounter.StepsCount / _stepCounter.MaxSteps * 100;
        
            if (percentageCompleted <= 30)
                _starsCount = 3;
            else if (percentageCompleted <= 60)
                _starsCount = 2;
            else
                _starsCount = 1;

            _wallet.IncreaseCoin(_starsCount * 100);

            for (int i = 0; i < _starsCount; i++)
                _stars[i].SetActive(true);
        }
    
        private void ShowVictoryScreen()
        {
            _winScreen.DOAnchorPos(_onScreenPosition, _animationDuration);
        }

        private IEnumerator ShowConfetti()
        {
            yield return new WaitForSeconds(1f);
        
            foreach (var effect in _effects)
                effect.gameObject.SetActive(true);
        }
    }
}