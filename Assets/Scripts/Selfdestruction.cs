using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruction : MonoBehaviour
{
    [SerializeField] bool destroy;

    void Update()
    {
        if (destroy)
            Destroy(gameObject);
    }
}
