using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    public class PauseScreen : AbstractScreen
    {
        public override void OpenScreen()
        {
            base.OpenScreen();
            StartCoroutine(StartPause());
            // Time.timeScale = 0;
        }

        public override void CloseScreen()
        {
            Time.timeScale = 1;
            base.CloseScreen();
        }

        private IEnumerator StartPause()
        {
            yield return new WaitForSeconds(0.7f);
            Time.timeScale = 0;
        }
    }
}
