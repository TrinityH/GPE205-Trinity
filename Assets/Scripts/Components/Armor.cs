using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    // Start is called before the first frame update
    //Health variables
    public float currentArmor;
    public float maxArmor;
    // Start is called before the first frame update
    void Start()
    {
        currentArmor = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float amount, Pawn owner)
    {
        currentArmor = currentArmor - amount;
        currentArmor = Mathf.Clamp(currentArmor, 0, maxArmor);

        if (currentArmor <= 0)
        {
            //Die(owner);
        }
    }

    public void Armorize(float amount, Pawn owner)
    {
        currentArmor = currentArmor + amount;
        currentArmor = Mathf.Clamp(currentArmor, 0, maxArmor);
    }

   /* public void Die(Pawn owner)
    {
        Destroy(gameObject);
    }*/


}
