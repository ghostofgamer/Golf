using UI.Screens;
using UnityEngine;

namespace UI.Buttons
{
    public class LevelChangerButton : AbstractButton
    {
        private const string SceneLoader = "LevelsScene";
    
        [SerializeField] private int _index;
        [SerializeField] private int _price;
        [SerializeField] private GameObject _openObject;
        [SerializeField] private GameObject _closeObject;
        [SerializeField]private LoadingScreen _loadingScreen;

        public int Price => _price;
    
        protected override void OnClick()
        {
            PlayerPrefs.SetInt("CurrentLevel",_index);
            _loadingScreen.LoadScene(SceneLoader);
            // SceneManager.LoadScene(SceneLoader);
        }

        public void OpenLevel()
        {
            Button.interactable = true;
            _closeObject.SetActive(false);
            _openObject.SetActive(true);  
        }

        public void CloseLevel()
        { 
            Button.interactable = false;
            _closeObject.SetActive(true);
            _openObject.SetActive(false);
        }
    }
}
