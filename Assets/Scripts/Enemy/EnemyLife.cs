using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; 

public class EnemyLife : MonoBehaviour
{
  
     public int MaxHealth = 60;
    public int CurrentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        //healthval = 60;
        CurrentHealth = MaxHealth;
        healthBar.SetHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       //health.text = "Wizard: " + healthval; 
       if (CurrentHealth <= 0){
           Destroy(gameObject);
       }
    }
    private void OnTriggerEnter(Collider other){
         if (other.gameObject.CompareTag("Sword")){
             TakeDamage(15);
        }

        if (other.gameObject.CompareTag("Ball")){
             TakeDamage(20);
        }
    }
    private void TakeDamage(int damage){
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);
    }

}
