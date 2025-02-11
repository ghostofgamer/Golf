using UnityEngine;

namespace UI.Buttons
{
    public abstract class ChangeAudioButton : AbstractButton
    {
        [SerializeField]private AudioIconViewer _audioIconViewer;

        protected virtual void ChangeValue()
        {
            _audioIconViewer.StartUI();
        }
    }
}
