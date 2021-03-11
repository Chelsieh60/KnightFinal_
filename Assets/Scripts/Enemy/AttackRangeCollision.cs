using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeCollision : MonoBehaviour
{
    public bool playatk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other){

        //if it is the player the enemy collides with
        if (other.gameObject.CompareTag("Sword")){

            //play attack animation
            playatk = true;
        }

        else{
            //do not play animation
            playatk = false;
        }
    }
}
