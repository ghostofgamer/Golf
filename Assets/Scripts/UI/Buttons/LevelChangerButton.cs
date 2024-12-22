using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerButton : AbstractButton
{
    private const string SceneLoader = "LevelsScene";
    
    [SerializeField] private int _index;
    
    protected override void OnClick()
    {
        PlayerPrefs.SetInt("CurrentLevel",_index);
        SceneManager.LoadScene(SceneLoader);
    }
}
