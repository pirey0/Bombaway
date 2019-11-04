using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoblinCounter : Singleton<GoblinCounter>
{
    [SerializeField] int scorePerGoblin;

    int count;
    int totalGoblins;

    public static event System.Action CollectedAllGoblins;
    public static event System.Action GoblinAdded;

    public int CollectedGoblins { get => Instance.count; }
    public int TotalGoblins { get => Instance.totalGoblins; }

    void Start()
    {
        totalGoblins = GameObject.FindObjectsOfType<Goblin>().Length;
        count = 0;
    }

    protected override void OnSceneChanged(Scene arg0, Scene arg1)
    {
        totalGoblins = GameObject.FindObjectsOfType<Goblin>().Length;
        count = 0;
    }

    public static void AddGoblin ()
    {
        if(Instance == null)
        {
            return;
        }

        Instance.count++;
        Score.Add(Instance.scorePerGoblin);
        GoblinAdded?.Invoke();

        if(Instance.totalGoblins <= Instance.count)
        {
            CollectedAllGoblins?.Invoke();
        }

    }

}
