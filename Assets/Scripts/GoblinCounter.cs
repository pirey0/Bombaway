using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCounter : MonoBehaviour
{
    public static GoblinCounter instance;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    public static void AddGoblin ()
    {
        if (instance != null)
            instance.count++;
    }

    void OnGUI ()
    {
        GUI.Box(new Rect(100,100,100,100),"Goblis: " + count);
    }
}
