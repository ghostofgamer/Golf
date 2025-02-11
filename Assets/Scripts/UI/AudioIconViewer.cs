using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AudioIconViewer : MonoBehaviour
    {
        [SerializeField]private string Key;
    
        [SerializeField] protected Sprite SpriteOn;
        [SerializeField] protected Sprite SpriteOff;
        [SerializeField] protected Image Image;

        private bool _value;

        private void OnEnable()
        {
            StartUI();
        }

        public void StartUI()
        {
            _value = PlayerPrefs.GetInt(Key, 1) == 1;
            Debug.Log(_value );
            Image.sprite = _value ? SpriteOn : SpriteOff;
        }
    }
}