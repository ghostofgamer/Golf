using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerButton : AbstractButton
{
    private const string SceneLoader = "LevelsScene";
    
    [SerializeField] private int _index;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _openObject;
    [SerializeField] private GameObject _closeObject;

    public int Price => _price;


    protected override void OnClick()
    {
        PlayerPrefs.SetInt("CurrentLevel",_index);
        SceneManager.LoadScene(SceneLoader);
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
