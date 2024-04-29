using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{

    //Variables
    public float damageDone;
    public Pawn owner;

    public void OnTriggerEnter(Collider other)
    {
        // Get the Health component from the Game Object that has the Collider that we are overlapping
        Health otherHealth = other.gameObject.GetComponent<Health>();
        Armor otherArmor = other.gameObject.GetComponent<Armor>();
        Pawn otherPawn = other.gameObject.GetComponent<Pawn>();
        // Only damage if it has a Health component
        if (otherHealth != null && owner != null && otherArmor != null)
        {
            // Do damage
            if(otherArmor.currentArmor > 0 )
            {
                otherArmor.TakeDamage(damageDone, owner);
            }
            else
            {
                otherHealth.TakeDamage(damageDone, owner);
            }
            
            
        }


        // Destroy ourselves, whether we did damage or not
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
