using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour, IAffectable
{
    [SerializeField] GameObject prototypePrefab;
    [SerializeField] Transform spawnLocation;
    [SerializeField] float spawnForce;
    [SerializeField] bool bombsSpawnTriggered;

    public void OnActivate(GameObject source)
    {
        if (!prototypePrefab || !spawnLocation) return;

        var instance = Instantiate(prototypePrefab, spawnLocation.position, Quaternion.identity);
        var rb = instance.GetComponent<Rigidbody2D>();

        if (rb)
        {
            rb.AddForce(spawnLocation.right * spawnForce, ForceMode2D.Impulse);
        }

        if (bombsSpawnTriggered)
        {
            var bomb = instance.GetComponent<Bomb>();
            if (bomb)
            {
                bomb.TriggerFuse();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnLocation)
            Gizmos.DrawWireSphere(spawnLocation.position, 0.1f);
    }
}
