using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour, IEffectable
{
    [SerializeField]
    GameObject destructedVersion;

    [SerializeField] int scorePerExplode;

    public void Explode(Bomb source)
    {
        Debug.Log(name + " destroyed by explosion");

        if (destructedVersion != null)
        {
            Instantiate(destructedVersion, transform.position, Quaternion.identity);
        }

        Score.Instance.Add(scorePerExplode);
        Destroy(gameObject);
    }
}
