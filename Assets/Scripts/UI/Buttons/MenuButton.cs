using UI.Screens;
using UnityEngine;

namespace UI.Buttons
{
    public class MenuButton : AbstractButton
    {
        [SerializeField] private LoadingScreen _loadingScreen;
    
        private const string MainMenu = "MainMenu";

        protected override void OnClick() => _loadingScreen.LoadScene(MainMenu);
    }
}
