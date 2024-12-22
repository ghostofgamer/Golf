using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : AbstractButton
{
    [SerializeField] private Settings _settings;
    
    protected override void OnClick()
    {
        _settings.ChangeSound();
    }
}
