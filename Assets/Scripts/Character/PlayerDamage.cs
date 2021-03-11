using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
      private void OnTriggerEnter(Collider other){
          if (other.gameObject.tag == "Enemy")
      {
          
            /*Slime slime = other.GetComponent<Slime>();
            Bat bat = other.GetComponent<Bat>();
             SecEnemyLife wizard = other.GetComponent<SecEnemyLife>();
            EnemyLife rabbit = other.GetComponent<EnemyLife>();

            if (slime != null)
            {
                slime.healthval -= 4;
            }
            else if (bat != null)
            {
                bat.healthval -= 3;
            }
            else if (wizard != null)
            {
                wizard.CurrentHealth -= 20;
            }
           // else if (rabbit != null)
            //{
               // rabbit.healthval -= 2;
            //}
            Debug.Log("Creature!");*/
        }
    }
}
    

