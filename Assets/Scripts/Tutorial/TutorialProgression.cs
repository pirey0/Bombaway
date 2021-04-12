using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialProgression : MonoBehaviour
{
    Tutorial tutorial;
    [SerializeField] int stepToEnable;

    protected virtual void Start()
    {
        tutorial = GameObject.FindWithTag("Tutorial").GetComponent<Tutorial>();
        tutorial.AddStepThatNeedsToGetEnabled(stepToEnable);
    }

    protected virtual void ActivateStep()
    {
        Debug.LogWarning("enabled step " + stepToEnable + " in the tutoial");
        tutorial.EnableStep(stepToEnable);
    }
}
