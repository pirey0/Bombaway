using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombsAndGoblinsTracker : Singleton<BombsAndGoblinsTracker>
{
    [SerializeField] int scorePerGoblin;

    int goblinsCollected;
    int totalGoblins;
    int bombsLeft;

    public event System.Action CollectedAllGoblins;
    public event System.Action GoblinAdded;
    public event System.Action OutOfBombs;

    public int CollectedGoblins { get => Instance.goblinsCollected; }
    public int TotalGoblins { get => Instance.totalGoblins; }

    protected override void Awake()
    {
        base.Awake();
        totalGoblins = GameObject.FindObjectsOfType<Goblin>().Length;
        bombsLeft = GameObject.FindObjectsOfType<Bomb>().Length;
        goblinsCollected = 0;
    }

    public void AddGoblin()
    {
        if (Instance == null)
        {
            return;
        }

        Instance.goblinsCollected++;
        Score.Instance.Add(ScoreType.Goblin, Instance.scorePerGoblin);

        GoblinAdded?.Invoke();

        if (Instance.totalGoblins <= Instance.goblinsCollected)
        {
            CollectedAllGoblins?.Invoke();
        }

    }

    public void RemoveBomb()
    {
        bombsLeft--;
        if (bombsLeft <= 0)
        {
            OutOfBombs?.Invoke();
        }
    }

}
