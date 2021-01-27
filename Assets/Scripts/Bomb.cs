using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Experimental.Rendering.Universal;

public class Bomb : MonoBehaviour, IEffectable, IPickupable
{
    public static event System.Action OutOfBombs;

    [SerializeField] float triggerDuration;
    [SerializeField] float explosionRadius;
    [SerializeField] AnimationClip fuseAnimation;
    [SerializeField] float pointLightRadiusIn, pointLightRadiusOut;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float explosionForce;
    [SerializeField] int scorePerExplosion;

    private bool triggered, exploded;
    private float triggerTime;

    Rigidbody2D rigidbody;
    Animator animator;
    Light2D light2d;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        light2d = GetComponentInChildren<Light2D>();
    }

    private void Update()
    {
        if (exploded)
        {
            return;
        }

        if (triggered)
        {
            if (Time.time - triggerTime >= triggerDuration)
            {
                Explode();
            }
        }
    }

    [Button]
    public void TriggerFuse()
    {
        if (triggered || exploded)
        {
            return;
        }


        Debug.Log("Bomb triggered");

        animator?.Play(fuseAnimation.name);
        animator.speed = 1 / triggerDuration;
        triggered = true;
        triggerTime = Time.time;

        light2d.pointLightOuterRadius = pointLightRadiusOut;
        light2d.pointLightInnerRadius = pointLightRadiusIn;
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

            if (effectable == null)
            {
                continue;
            }

            var dist = Vector3.Distance(transform.position, ef.transform.position);

            if (dist <= explosionRadius)
            {
                effectable.Explode(this);
            }
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

        Score.Add(scorePerExplosion);

        var bs = GameObject.FindObjectsOfType<Bomb>();
        Debug.Log("Bombs Left: " + (bs.Length - 1));

        if (bs.Length <= 1)
        {
            OutOfBombs?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public void Explode(Bomb source)
    {
        rigidbody.AddForce((transform.position - source.transform.position) * explosionForce);
        TriggerFuse();
    }

    public void PickUp()
    {
        TriggerFuse();
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
        if (exploded || this == null)
            return null;

        return transform;
    }
}
