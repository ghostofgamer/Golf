using UnityEngine.SceneManagement;

public class AgainLevelButton : AbstractButton
{
    protected override void OnClick()
    {
        RestartCurrentScene();
    }

    private void RestartCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
