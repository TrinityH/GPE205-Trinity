using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public HealthPowerUp powerup;
    public GameObject particleEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        // variable to store other object's PowerupController - if it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If the other object has a PowerupController
        if (powerupManager != null)
        {
            // Add the powerup
            powerupManager.Add(powerup);
            //Start particles
            particleEffect.SetActive(true);
            //Debug
            Debug.Log("Particles are particling!");
            // Destroy this pickup
            Destroy(gameObject);
        }

    }


}
