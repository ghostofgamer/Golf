using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField] private GameObject[] _allLevels;

    private int _defaultValue = 0;

    private void OnEnable()
    {
        Open();
    }

    private void Open()
    {
        // int index = PlayerPrefs.GetInt("LevelCompleted", _defaultValue);
        int starCount = PlayerPrefs.GetInt("Star", 0);

        for (int i = 0; i < _allLevels.Length; i++)
        {
            if (_allLevels[i].GetComponent<LevelChangerButton>().Price <= starCount)
                _allLevels[i].GetComponent<LevelChangerButton>().OpenLevel();
            else
                _allLevels[i].GetComponent<LevelChangerButton>().CloseLevel();
            
            /*if (i > index)
            {
                _allLevels[i].GetComponent<LevelChangerButton>().CloseLevel();
            }
            else
            {
                _allLevels[i].GetComponent<LevelChangerButton>().OpenLevel();
            }*/


            //_allLevels[i].GetComponent<Image>().color = Color.green;
        }
    }
}