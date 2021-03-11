using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecHealthCount : MonoBehaviour
{
  Text health;
    public static int healthval;
    
    // Start is called before the first frame update
    void Start()
    {
        
        healthval = 40;
        health = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text =  "Health: " + healthval;
    }
}
