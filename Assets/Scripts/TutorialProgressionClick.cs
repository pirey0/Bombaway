using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialProgressionClick : TutorialProgression
{
    private void OnMouseDown()
    {
        ActivateStep();
    }
}
