using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour, IExplodingElement
{
    [SerializeField]
    GameObject destructedVersion;

    [SerializeField] int scorePerExplode;
    [SerializeField] ScoreType scoreType;

    public void Explode(Bomb source)
    {
        Debug.Log(name + " destroyed by explosion");

        if (destructedVersion != null)
        {
            Instantiate(destructedVersion, transform.position, Quaternion.identity);
        }

        Score.Instance.Add(scoreType, scorePerExplode);
        Destroy(gameObject);
    }
}
