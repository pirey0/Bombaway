using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] float radius = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Pressure plate triggered by {collision.gameObject.name}");
        var matches = BombsAndGoblinsUtility.FindAllEffectableComponentsInRange<IAffectable>(transform.position, radius);
        foreach (var m in matches)
        {
            m.OnActivate(collision.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
