using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecPlayerController : MonoBehaviour
{ 
    //floats
    public float HorizontalInput;
    public float VerticalInput;
    public float move = 5.0f;
    public float x;
    public float y;
    public float z;
    public float attack_move_mod = 1;
    
    //Ints
    public int MaxHealth = 150;
    public int CurrentHealth;
    public int MaxMana = 50;
    public int CurrentMana;

    //Character animation node
    private Animator charAnimator;

    //audio

    //vectors
    public Vector3 bosstrigger;

    //bools
    public bool playwalk;
    public bool playrun;
    public bool playswing;
    public bool bosstrig;
    public bool playshoot;
    public bool cooldown = true;
    public bool gethealth = true;
    public bool manaCool = true;
    public bool getmana = true;

    //game objects
    public GameObject healthPot;
    public GameObject manaPot;
    public GameObject projectileprefab;
    //public GameObject shieldeprefab; 
    
   //Healthbar
    public HealthBar healthBar;
    public ManaBar ManaBar;


    void Start()
    {
        //getting the character animator component
        charAnimator = GetComponent<Animator>();

        //setting health bar to max health at the start
        CurrentHealth = MaxHealth;
        healthBar.SetHealth(MaxHealth);

        //setting mana bar to max mana at the start
        CurrentMana = MaxMana;
        ManaBar.Setmana(MaxMana);
    }

    
    void Update()
    {
        //Movement input
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * move * VerticalInput);
        transform.Rotate(Vector3.up, HorizontalInput);

        AnimationClip currentAnimClip = charAnimator.GetCurrentAnimatorClipInfo(0)[0].clip;
        AnimatorStateInfo currentAnimState = charAnimator.GetCurrentAnimatorStateInfo(0);

        //Movement controls and playing animations
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playrun = true;
                playwalk = false;
                attack_move_mod = 1;
            }
            else
            {
                if (Input.GetKey(KeyCode.F)){
                    attack_move_mod = 0;
                }
                playrun = false;
                playwalk = true;
            }
        }
        else
        {
            attack_move_mod = 1;
            playwalk = false;
        }
        if (Input.GetKey(KeyCode.LeftShift)){
            playrun = true;
                attack_move_mod = 1;
        }
        else{
            playrun = false;
        }

        if (Input.GetKey(KeyCode.F))
        {
            playswing = true;
        }
        else
        {
            playswing = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && CurrentMana >= 10){
            playshoot = true;
            CurrentMana -= 10;
            ManaBar.Setmana(CurrentMana);
            Instantiate(projectileprefab, transform.position, projectileprefab.transform.rotation);
        }
        else{
            playshoot = false;
        }
        //if (Input.GetKeyDown(KeyCode.C)){
            //Instantiate(shieldeprefab, transform.position - new Vector3(0f,-2f,6), shieldeprefab.transform.rotation);
        //}

        //Play set the booleans for the different animations
        charAnimator.SetBool("Swing", playswing);
        charAnimator.SetBool("Run", playrun);
        charAnimator.SetBool("Walk", playwalk);
        charAnimator.SetBool("Shoot", playshoot);


        //Game is over when player life hits 0
        if (CurrentHealth <=0){
            SceneManager.LoadScene("EndLosing");
        }

        //only allowing coroutine to play once when activated
        if (CurrentHealth < MaxHealth && gethealth == true){
             gethealth = false;
             StartCoroutine(addHealth());
             Debug.Log("H");
             }
             else if (CurrentHealth == MaxHealth){
                 gethealth = true;
             }
        if (CurrentHealth < MaxHealth){
            StartCoroutine(healthCool());
            //Debug.Log("cool down started");
        }
        else {
            cooldown = true;
        }
        if (CurrentMana < MaxMana && getmana == true){
            getmana = false;
            StartCoroutine(addMana());
            //Debug.Log("cooling down started");
        }
        else if (CurrentMana == MaxMana) {
            getmana = true;
            manaCool = true;
        }
        if (CurrentMana < MaxMana){
            StartCoroutine(manaCooling());
        }

             
    }
    

    //adding health over time when player has taken damage
    //if the players current health is less than their full health
    //add 5 points to health
    //set current health to health plus the 5 points
    //wait some time then do it again
    //if current health is at full health
    //do not add any health 
        IEnumerator addHealth(){
        while (CurrentHealth < MaxHealth){
        CurrentHealth += 5;
        Debug.Log(CurrentHealth);
        healthBar.SetHealth(CurrentHealth);
        yield return new WaitForSeconds(5.0f);
        }
    }
    
    //allowing player to use a health potion to add health
    IEnumerator healthCool(){
        while (CurrentHealth <= MaxHealth && Input.GetKeyDown(KeyCode.E) && cooldown == true){
                cooldown = false;
                healthPot.SetActive(false);
                 CurrentHealth += 10;
                 healthBar.SetHealth(CurrentHealth);
                 Debug.Log("health potion added");
                yield return new WaitForSeconds(8.0f);
                cooldown = true;
                healthPot.SetActive(true);
             }
    }
    IEnumerator addMana(){
        while (CurrentMana < MaxMana){
        CurrentMana += 2;
        Debug.Log(CurrentMana);
        ManaBar.Setmana(CurrentMana);
        yield return new WaitForSeconds(4.0f);
        }
        }

    //allowing player to add mana
    IEnumerator manaCooling(){
        while (CurrentMana <= MaxMana && Input.GetKeyDown(KeyCode.Q) && manaCool == true){
                manaCool = false;
                manaPot.SetActive(false);
                 CurrentMana += 10;
                 ManaBar.Setmana(CurrentMana);
                 Debug.Log("mana potion added");
                yield return new WaitForSeconds(8.0f);
                manaCool = true;
                manaPot.SetActive(true);
             }
    }


    bool IsPlaying(AnimationClip curAnim, AnimatorStateInfo curAnimState)
    {
        // 0.1 seconds of the sword animation < total length of the sword animation
        return (curAnim.length * curAnimState.normalizedTime) < curAnim.length;
    }

    //Take damage on collison with enemy
    private void OnTriggerEnter(Collider other){
         if (other.gameObject.CompareTag("Enemy")){
             TakeDamage(10);
        }
        if (other.gameObject.CompareTag("Wizard")){
            TakeDamage(15);
        }
      
    }

    //Dealing the damage from enemy
    private void TakeDamage(int damage){
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);
        
    }
    
}
