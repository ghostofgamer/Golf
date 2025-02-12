using Singletons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public abstract class AbstractButton : MonoBehaviour
    {
        protected Button Button {get; private set; }
    
        private void Awake()
        {
            Button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            Button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnClick);
        }

        protected virtual void OnClick()
        {
            SoundGamePlayer.Instance.PlayButtonClickSound();
        }
    }
}
