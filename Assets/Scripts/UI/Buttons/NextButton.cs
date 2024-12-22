using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : AbstractButton
{
    private const string SceneLoader = "LevelsScene";
    
    private int _defaultIndex = 0;
    
    protected override void OnClick()
    {
        int currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel",_defaultIndex);
        int index = currentLevelIndex + 1;
        PlayerPrefs.SetInt("CurrentLevel",index);
        SceneManager.LoadScene(SceneLoader);
    }
}
