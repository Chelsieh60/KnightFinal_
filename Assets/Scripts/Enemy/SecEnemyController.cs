using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SecEnemyController : MonoBehaviour
{
    public float LookRad = 10f;
    Transform target;
    NavMeshAgent agent;
    public GameObject Player;
    private Animator charAnimator;
    public bool playdead;
    public bool playatk;
    public bool playdmg;
   
    // Start is called before the first frame update
    void Start()
    {
        //character animation
        charAnimator = GetComponent<Animator>();

        //reference to player
         PlayerManager PlayerManager = Player.GetComponent<PlayerManager>();

         //getting navmeshagent info
        agent = GetComponent<NavMeshAgent>();

        //setting player as target
        target = Player.transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        //player distance to enemy
        float distance = Vector3.Distance(target.position, transform.position);
        
        //if player is in radius of enemy
        if (distance <= LookRad){

            //enemy will go to player
            agent.SetDestination(target.position);
        }

        //if enemy is in stopping distance 
        if (distance <= agent.stoppingDistance){

            //turn to player direction
            faceTarget();
        }
        if (distance <= 15){
            playatk = true;
        }
        else{
            playatk = false;
        }

        charAnimator.SetBool("damage_001", playdmg);
        charAnimator.SetBool("attack_short_001", playatk);
        charAnimator.SetBool("dead", playdead);
    }

    //allows enemy to turn smoothly and look at player
    void faceTarget(){

        //getting players position from enemy 
        Vector3 direction = (target.position - transform.position).normalized;

        //where enemy should be looking
        Quaternion lookPos = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        //rotating the enemy to look the right direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookPos, Time.deltaTime * 5);
    }

    //just an outline of how big the radius of the enemy is
    void OnDrawGizmosSelected(){

        //outline color
        Gizmos.color = Color.red;

        //outline shape, position, and what it is outlining
        Gizmos.DrawWireSphere(transform.position, LookRad);
    }

    //this next part only applies to final boss
   /* void OnTriggerEnter(Collider other){

        //if it is the player the enemy collides with
        if (other.gameObject.CompareTag("Sword")){

            //play attack animation
            playatk = true;
        }

        else{
            //do not play animation
            playatk = false;
        }
    }*/
}
