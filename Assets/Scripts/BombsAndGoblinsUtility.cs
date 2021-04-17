using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BombsAndGoblinsUtility
{
    public static List<T> FindAllEffectableComponentsInRange<T>(Vector3 position, float range)
    {
        var effectables = GameObject.FindGameObjectsWithTag("Effectable");
        List<T> results = new List<T>();

        foreach (var ef in effectables)
        {
            var effectable = ef.GetComponent<T>();

            if (effectable == null)
            {
                continue;
            }

            var dist = Vector3.Distance(position, ef.transform.position);

            if (dist <= range)
            {
                results.Add(effectable);
            }
        }
        return results;
    }

}
