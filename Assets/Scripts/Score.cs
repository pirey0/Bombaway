using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Score : Singleton<Score>
{
    private int[] scores = new int[5];
    private float startTime;


    public int TotalScore { get => GetTotalScore(); }
    public float TotalTime { get => Time.time - startTime; }

    private int GetTotalScore()
    {
        float sum = scores.Sum();
        sum = Mathf.Max(0, sum - sum % 10);
        return Mathf.RoundToInt(sum);
    }

    private void Start()
    {
        Debug.Log("Started Score tracking");
        startTime = Time.time;
    }

    public void OnLevelEnd()
    {
        Add(ScoreType.Time, 60 - Mathf.RoundToInt(Time.time - startTime));
    }

    public int GetScoreFor(ScoreType type)
    {
        return scores[(int)type];
    }

    public void Add(ScoreType type, int amount)
    {
        scores[(int)type] += amount;
    }

}

public enum ScoreType
{
    None,
    Bomb,
    Goblin,
    Bookshelf,
    Time
}
