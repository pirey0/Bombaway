using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Step[] steps;
    int currentStep = -1;

    [SerializeField] Transform light;
    [SerializeField] TMP_Text text;
    [SerializeField] Granpa granpa;


    private void Start()
    {
        granpa.PlayIntro();
    }

    [Button]
    public void NextStep()
    {
        currentStep++;

        if (currentStep == steps.Length)
        {
            granpa.PlayOutro();
            return;
        }
        else if(currentStep > steps.Length)
        {
            //SCORE
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

    [System.Serializable]
    public class Step
    {
        public Transform lightPosition;
        [TextArea(2,10)] public string text;
        public bool makeGnomeTalk;

    }
}
