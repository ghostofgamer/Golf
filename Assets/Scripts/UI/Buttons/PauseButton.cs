using UI.Screens;
using UnityEngine;

namespace UI.Buttons
{
    public class PauseButton : AbstractButton
    {
        [SerializeField] private PauseScreen _pauseScreen;
        
        protected override void OnClick()
        {
            base.OnClick();
            _pauseScreen.OpenScreen();
        }
    }
}
