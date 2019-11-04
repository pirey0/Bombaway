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

        if(Instance.totalGoblins <= Instance.count)
        {
            CollectedAllGoblins?.Invoke();
        }

    }

    void OnGUI ()
    {
        GUI.Box(new Rect(100,100,100,100),"Goblis: " + count + "/ " + totalGoblins);
    }
}
