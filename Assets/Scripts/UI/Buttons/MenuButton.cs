using UnityEngine.SceneManagement;

public class MenuButton : AbstractButton
{
    private const string MainMenu = "MainMenu";
    
    protected override void OnClick()=> SceneManager.LoadScene(MainMenu);
}
