using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;

    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    void Update()
    {
        // If it is time to spawn a pickup
        if (Time.time > nextSpawnTime)
        {
            // Spawn it and set the next time
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
