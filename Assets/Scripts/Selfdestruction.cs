using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruction : MonoBehaviour
{
    [SerializeField] bool destroy;

    // Update is called once per frame
    void Update()
    {
        if (destroy)
            Destroy(gameObject);
    }
}
