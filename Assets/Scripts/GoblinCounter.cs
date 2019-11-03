using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCounter : MonoBehaviour
{
    public static GoblinCounter instance;
    int count;
    int totalGoblins;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }

        totalGoblins = GameObject.FindObjectsOfType<Goblin>().Length;
    }

    public static void AddGoblin ()
    {
        if (instance != null)
            instance.count++;
    }

    void OnGUI ()
    {
        GUI.Box(new Rect(100,100,100,100),"Goblis: " + count + "/ " + totalGoblins);
    }
}
