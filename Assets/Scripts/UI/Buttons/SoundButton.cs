using Singletons;

namespace UI.Buttons
{
    public class SoundButton : ChangeAudioButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            ChangeValue();
        }

        protected override void ChangeValue()
        {
            SoundSettings.Instance.SetSound(!SoundSettings.Instance.IsSoundOn);
            base.ChangeValue();
        }
    }
}