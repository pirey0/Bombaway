using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

public class Goblin : MonoBehaviour, IExplodingElement, IClickable
{

    [SerializeField] GameObject destroyedGoblin;

    [SerializeField] int scoreForDeath;

    [Button]
    void Collect()
    {
        BombsAndGoblinsTracker.Instance.AddGoblin();
        Destroy(gameObject);
    }

    public void Explode(Bomb source)
    {
        Debug.Log("Goblin died through explosion");

        if (destroyedGoblin != null)
            Instantiate(destroyedGoblin, transform.position, Quaternion.identity);

        Destroy(gameObject);
        Score.Instance.Add(ScoreType.Goblin, scoreForDeath);
    }

    public void Click()
    {
        Collect();
    }
}
