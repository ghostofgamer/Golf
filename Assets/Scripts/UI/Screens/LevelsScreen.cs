using UI.Buttons;
using UI.Screens;
using UnityEngine;

public class LevelsScreen : AbstractScreen
{
    [SerializeField] private GameObject[] _allLevels;

    private int _defaultValue = 0;

    public override void OpenScreen()
    {
        base.OpenScreen();
        Open();
    }

    private void Open()
    {
        int index = PlayerPrefs.GetInt("LevelCompleted", _defaultValue);

        for (int i = 0; i < _allLevels.Length; i++)
        {
            if (i > index)
                _allLevels[i].GetComponent<LevelChangerButton>().CloseLevel();
            else
                _allLevels[i].GetComponent<LevelChangerButton>().OpenLevel();
        }
    }
}