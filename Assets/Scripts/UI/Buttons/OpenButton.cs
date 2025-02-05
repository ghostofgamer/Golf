using UI.Screens;
using UnityEngine;

namespace UI.Buttons
{
    public class OpenButton : AbstractButton
    {
        [SerializeField] private AbstractScreen _screen;

        protected override void OnClick() => _screen.OpenScreen();
    }
}