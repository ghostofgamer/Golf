using Singletons;

namespace UI.Buttons
{
    public class SFXButton : ChangeAudioButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            ChangeValue();
        }

        protected override void ChangeValue()
        {
            SoundSettings.Instance.SetSFX(!SoundSettings.Instance.IsSFXOn);
            base.ChangeValue();
        }
    }
}