using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Goblin : MonoBehaviour
{

    
    void OnMouseDown ()
    {
        Collect();
    }

    [Button]
    void Collect ()
    {
        GoblinCounter.AddGoblin();
        Destroy(gameObject);
    }
}
