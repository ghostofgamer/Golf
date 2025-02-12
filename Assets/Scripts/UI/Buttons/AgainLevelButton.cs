using UI.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public class AgainLevelButton : AbstractButton
    {
        [SerializeField] private LoadingScreen _loadingScreen; 
    
        protected override void OnClick()
        {
            base.OnClick();
            RestartCurrentScene();
        }

        private void RestartCurrentScene()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            _loadingScreen.LoadScene(currentSceneName);
            // SceneManager.LoadScene(currentSceneName);
        }
    }
}
