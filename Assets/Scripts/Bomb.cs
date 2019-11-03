using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Bomb : MonoBehaviour, IEffectable, IPickupable
{
    [SerializeField] float triggerDuration;
    [SerializeField] float explosionRadius;

    private bool triggered, exploded;
    private float triggerTime;

    Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

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
        if(triggered || exploded)
        {
            return;
        }

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public void Explode(Bomb source)
    {
        TriggerFuse();
    }

    public void PickUp()
    {
        rigidbody.gravityScale = 0;
    }

    public void Release()
    {
        rigidbody.gravityScale = 1;
    }

    public Rigidbody2D GetRigidbody()
    {
        return rigidbody;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
