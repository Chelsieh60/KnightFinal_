using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCount : MonoBehaviour
{
    Text health;
    public static int healthval;
    
    // Start is called before the first frame update
    void Start()
    {
        
        healthval = 20;
        health = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text =  "Health: " + healthval;
    }

}
