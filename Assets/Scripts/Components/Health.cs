using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        owner.healthbar = GetComponentInChildren<Image>();
        if(owner.healthbar != null)
        {
            owner.healthbar.fillAmount -= 0.1f;
        }
        



        if (currentHealth <= 0)
        {
            Die(owner);
        }
    }

    public void Heal(float amount, Pawn owner)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        owner.healthbar = GetComponentInChildren<Image>();

        if (owner.healthbar != null && currentHealth < maxHealth)
        {
            owner.healthbar.fillAmount += 1f;
        }
    }

    public void Die(Pawn owner)
    {
        Destroy(gameObject);
        PlayerController player = GetComponent<PlayerController>();
        player.lives -= 1;
        Debug.Log(player.lives);
    }




}
