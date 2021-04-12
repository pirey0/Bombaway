using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialProgressionEnterAreaWithObject : TutorialProgression
{
    [SerializeField] GameObject objectToCheckFor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("smth entered trigger");

        if (collision.gameObject == objectToCheckFor)
            ActivateStep();
    }
}
