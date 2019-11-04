using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Step[] steps;
    int currentStep = -1;

    [SerializeField] Transform light;

    [Button]
    void NextStep()
    {
        currentStep++;

        if (currentStep >= steps.Length)
            return;

        Step step = steps[currentStep];

        light.position = step.lightPosition.position;
        

    }




    public class Step
    {
        public Transform lightPosition;

        [TextArea(2,10)]
        public string text;


    }
}
