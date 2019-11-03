using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

public class Goblin : MonoBehaviour, IEffectable, IClickable
{

    [Button]
    void Collect ()
    {
        GoblinCounter.AddGoblin();
        Destroy(gameObject);
    }

    public void Explode(Bomb source)
    {
        Debug.Log("Goblin died through explosion");
        Destroy(gameObject);
    }

    public void Click()
    {
        Collect();
    }
}
