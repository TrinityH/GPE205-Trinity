using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    //Health variables
    public float currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float amount, Pawn owner)
    {
        currentHealth = currentHealth - amount;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
