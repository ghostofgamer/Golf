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
        int index = PlayerPrefs.GetInt("LevelCompleted", _defaultValue);

        for (int i = 0; i < _allLevels.Length; i++)
        {
            if (i > index)
                return;

            _allLevels[i].GetComponent<Image>().color = Color.green;
        }
    }
}