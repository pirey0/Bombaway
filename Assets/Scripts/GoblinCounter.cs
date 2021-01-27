using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoblinCounter : Singleton<GoblinCounter>
{
    [SerializeField] int scorePerGoblin;

    int count;
    int totalGoblins;

    public event System.Action CollectedAllGoblins;
    public event System.Action GoblinAdded;

    public int CollectedGoblins { get => Instance.count; }
    public int TotalGoblins { get => Instance.totalGoblins; }

    void Start()
    {
        totalGoblins = GameObject.FindObjectsOfType<Goblin>().Length;
        count = 0;
    }

    public void AddGoblin ()
    {
        if(Instance == null)
        {
            return;
        }

        Instance.count++;
        Score.Instance.Add(Instance.scorePerGoblin);

        GoblinAdded?.Invoke();

        if(Instance.totalGoblins <= Instance.count)
        {
            CollectedAllGoblins?.Invoke();
        }

    }

}
