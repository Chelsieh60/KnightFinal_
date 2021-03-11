using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Slime : MonoBehaviour
{
     public TextMeshPro health;
    public int healthval;
    // Start is called before the first frame update
    void Start()
    {
        healthval = 10;
    }

    // Update is called once per frame
    void Update()
    {
       health.text = "Slime: " + healthval; 
       if (healthval <= 0){
           Destroy(gameObject);
       }
    }
}
