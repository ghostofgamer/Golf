using UI.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainLevelButton : AbstractButton
{
    [SerializeField] private LoadingScreen _loadingScreen; 
    
    protected override void OnClick()
    {
        RestartCurrentScene();
    }

    private void RestartCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        _loadingScreen.LoadScene(currentSceneName);
        // SceneManager.LoadScene(currentSceneName);
    }
}
