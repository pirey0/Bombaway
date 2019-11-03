using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour, IEffectable
{
    public void Explode(Bomb source)
    {
        Debug.Log(name + " destroyed by explosion");
        Destroy(gameObject);
    }
}
