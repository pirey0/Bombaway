using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Step[] steps;
    int currentStep = -1;

    [SerializeField] Transform light;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject nextButton;

    List<int> stepsThatNeedToGetEnabled = new List<int>();

    internal void AddStepThatNeedsToGetEnabled(int step)
    {
        stepsThatNeedToGetEnabled.Add(step);
    }

    [SerializeField] Granpa granpa;

    private void Start()
    {
        granpa.PlayIntro();
    }

    internal void EnableStep(int stepToEnable)
    {
        stepsThatNeedToGetEnabled.Remove(stepToEnable);

        if (!stepsThatNeedToGetEnabled.Contains(currentStep + 1))
        {
            SetActiveTutorialArrow(true);
        }

        //try next step
        NextStep();

    }

    [Button]
    public void NextStep()
    {
        if (!stepsThatNeedToGetEnabled.Contains(currentStep + 1))
        {

            currentStep++;

            if (currentStep == steps.Length)
            {
                granpa.PlayOutro();
                SetActiveTutorialArrow(false);
                return;
            }
            else if (currentStep > steps.Length)
            {
                //SCORE
                return;
            }

            Step step = steps[currentStep];
		    
            if (step.lightPosition == null)
            {
                light.position = new Vector3(-100, -100);
            }
            else
            {
                light.position = step.lightPosition.position;
            }
		    
            text.text = step.text;
		    
            if (step.makeGnomeTalk)
            {
                granpa.PlayTalk();
            }
        }

        if (stepsThatNeedToGetEnabled.Contains(currentStep+1)) {
            SetActiveTutorialArrow(false);
        }
    }

    void SetActiveTutorialArrow(bool status) {
        if (nextButton != null)
            nextButton.SetActive(status);
    }

    [System.Serializable]
    public class Step
    {
        public Transform lightPosition;
        [TextArea(2,10)] public string text;
        public bool makeGnomeTalk;

    }
}
