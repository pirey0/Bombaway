using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Bomb : MonoBehaviour
{
    [SerializeField] float triggerDuration;
    [SerializeField] float explosionRadius;

    private bool triggered, exploded;
    private float triggerTime;

    private void Update()
    {
        if (exploded)
        {
            return;
        }

        if (triggered)
        {
            if(Time.time - triggerTime >= triggerDuration)
            {
                Explode();
            }
        }
    }

    [Button]
    public void TriggerFuse()
    {
        triggered = true;
        triggerTime = Time.time;
    }

    [Button]
    public void Explode()
    {
        exploded = true;

        var effectables = GameObject.FindGameObjectsWithTag("Effectable");

        foreach (var ef in effectables)
        {
            var effectable = ef.GetComponent<IEffectable>();

            if(effectable == null)
            {
                continue;
            }

           var dist = Vector3.Distance(transform.position, ef.transform.position);

            if(dist <= explosionRadius)
            {
                effectable.Explode(this);
            }
        }
    }

}
