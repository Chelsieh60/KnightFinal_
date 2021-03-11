using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SecEnemyLife : MonoBehaviour
{
  
    //public TextMeshPro health;
    //public int healthval;
    public int MaxHealth = 400;
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
           SceneManager.LoadScene("EndWinning");
       }
    }
    private void OnTriggerEnter(Collider other){
         if (other.gameObject.CompareTag("Sword")){
             TakeDamage(20);
        }
        if (other.gameObject.CompareTag("Ball")){
             TakeDamage(30);
        }
    }
    private void TakeDamage(int damage){
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);
    }
}
