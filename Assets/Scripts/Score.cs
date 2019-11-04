using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : Singleton<Score>
{
    int currentScore = 0;

    public int Amount { get => currentScore; }

    protected override void OnSceneChanged(Scene arg0, Scene arg1)
    {
        currentScore = 0;
    }

    public static void Add(int amount)
    {
        Instance.currentScore += amount;
    }

}
