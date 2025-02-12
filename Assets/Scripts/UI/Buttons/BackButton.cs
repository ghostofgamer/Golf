using UnityEngine;

namespace UI.Buttons
{
    public class BackButton : AbstractButton
    {
        [SerializeField] private GameObject _screen;
    
        protected override void OnClick()
        {
            base.OnClick();
            _screen.SetActive(false);
        }
    }
}