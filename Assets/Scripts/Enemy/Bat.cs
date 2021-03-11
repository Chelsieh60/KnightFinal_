using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Bat : MonoBehaviour
{
     public TextMeshPro health;
    public int healthval;
    // Start is called before the first frame update
    void Start()
    {
        healthval = 15;
    }

    // Update is called once per frame
    void Update()
    {
       health.text = "Bat: " + healthval; 
       if (healthval <= 0){
           Destroy(gameObject);
       }
    }
}
