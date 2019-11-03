using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Bomb : MonoBehaviour, IEffectable, IPickupable
{
    [SerializeField] float triggerDuration;
    [SerializeField] float explosionRadius;
    [SerializeField] AnimationClip fuseAnimation;

    private bool triggered, exploded;
    private float triggerTime;

    Rigidbody2D rigidbody;
    Animator animator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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


        Debug.Log("Bomb triggered");

        animator?.Play(fuseAnimation.name);
        animator.speed = 1/triggerDuration;
        triggered = true;
        triggerTime = Time.time;
    }

    [Button]
    public void Explode()
    {
        Debug.Log("Bomb explodes");
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

        Destroy(gameObject);
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
        rigidbody.simulated = false;
    }

    public void Release()
    {
        rigidbody.simulated = true;
    }
}
