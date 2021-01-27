using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : Singleton<Score>
{
    int currentScore = 0;

    public int Amount { get => currentScore; }


    public void Add(int amount)
    {
        currentScore += amount;
    }

}
