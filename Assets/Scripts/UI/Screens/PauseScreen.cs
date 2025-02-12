using UnityEngine;

namespace UI.Screens
{
    public class PauseScreen : AbstractScreen
    {
        public override void OpenScreen()
        {
            base.OpenScreen();
            Time.timeScale = 0;
        }

        public override void CloseScreen()
        {
            Time.timeScale = 1;
            base.CloseScreen();
        }
    }
}