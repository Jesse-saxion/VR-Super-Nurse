using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskToRiseHand : Valve.VR.InteractionSystem.UIElement
{
    public GameObject Canvas;
    public HandAnimationCall Script;
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        Script.PlayHandAnim();
    }
}
