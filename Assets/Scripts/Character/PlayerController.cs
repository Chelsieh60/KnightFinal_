using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{ 
    //floats
    public float HorizontalInput;
    public float VerticalInput;
    public float move = 5.0f;
    private float attack_move_mod= 1;
    public float x;
    public float y;
    public float z;
    
    //Ints
    public int atkDamg;
    public int MaxHealth = 100;
    public int CurrentHealth;
    public int MaxMana = 50;
    public int CurrentMana;

    //Character animation node
    private Animator charAnimator;

    //audio
    //public AudioClip click;

    //vectors
    public Vector3 bosstrigger;

    //bools
    public bool playwalk;
    public bool playrun;
    public bool playswing;
    public bool bosstrig;
    public bool gethealth = true;
    public bool cooldown = true;
    public bool manaCool = true;
    public bool getmana = true;
    public bool playshoot;
    public bool hasHealth;
    public bool hasMana;
    public bool hasScroll;


    //game objects
    public GameObject HealthPotion;
    public GameObject ManaPotion;
    public GameObject Shield;
    public GameObject Necklace;
    public GameObject Helmet;
    public GameObject Cloak;
    public GameObject Ring;
    public GameObject Spell;
    public GameObject Inventory;
    public GameObject TheManaBar;
    public GameObject manaPot;
    public GameObject healthPot;
    public GameObject projectileprefab;
    public GameObject ControlMenu;
   
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
        if (hasScroll == true && hasMana == true && Input.GetKeyDown(KeyCode.Space) && CurrentMana >= 10){
            playshoot = true;
            CurrentMana -= 10;
            ManaBar.Setmana(CurrentMana);
            Instantiate(projectileprefab, transform.position, projectileprefab.transform.rotation);
        }
        else{
            playshoot = false;
        }

        //Play set the booleans for the different animations
        charAnimator.SetBool("Swing", playswing);
        charAnimator.SetBool("Run", playrun);
        charAnimator.SetBool("Walk", playwalk);
        charAnimator.SetBool("Shoot", playshoot);

        //Opening inventory
        if (Input.GetKey(KeyCode.I)){
            Inventory.SetActive(true);}
            if (Input.GetKeyUp(KeyCode.I)){
                Inventory.SetActive(false);
            }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ControlMenu.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            ControlMenu.SetActive(false);
        }

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
        else if (CurrentMana == MaxMana){
            manaCool = true;
            getmana = true;
        }
        if (CurrentMana < MaxMana){
            StartCoroutine(manaCooling());
        }

        transform.Translate(Vector3.forward * Time.deltaTime * move * VerticalInput * attack_move_mod);
        transform.Rotate(Vector3.up, HorizontalInput);
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
        IEnumerator healthCool(){
        while (CurrentHealth <= MaxHealth && Input.GetKeyDown(KeyCode.E) && cooldown == true && hasHealth == true){
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
        yield return new WaitForSeconds(3.0f);
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

#region inventory collection
    private void OnCollisionEnter(Collision other){
       

            //add health potion
            if (other.gameObject.CompareTag("HealthPotion")){
                HealthPotion.SetActive(true);
                healthPot.SetActive(true);
                hasHealth = true;
                Destroy(other.gameObject);
            }

            //add mana potion
            if (other.gameObject.CompareTag("ManaPotion")){
                ManaPotion.SetActive(true);
                TheManaBar.SetActive(true);
                manaPot.SetActive(true);
                Destroy(other.gameObject);
                hasMana = true;
            }

            //add shield
            if (other.gameObject.CompareTag("Shield")){
                Shield.SetActive(true);
                Destroy(other.gameObject);
            }

            //add ring
            if (other.gameObject.CompareTag("Ring")){
                Ring.SetActive(true);
                Destroy(other.gameObject);
            }

            //add cloak
            if (other.gameObject.CompareTag("Cloak")){
                Cloak.SetActive(true);
                Destroy(other.gameObject);
            }

            //add spell
            if (other.gameObject.CompareTag("Spell")){
                hasScroll = true;
                Spell.SetActive(true);
                Destroy(other.gameObject);
            }

            //add helmet
            if (other.gameObject.CompareTag("Helmet")){
                Helmet.SetActive(true);
                Destroy(other.gameObject);
            }

            //add necklace
            if (other.gameObject.CompareTag("Necklace")){
                Necklace.SetActive(true);
                Destroy(other.gameObject);
            }
            
        }
        
    #endregion

    //Take damage on collison with enemy
    private void OnTriggerEnter(Collider other){
         if (other.gameObject.CompareTag("Enemy")){
             TakeDamage(15);
        }
        if (other.gameObject.CompareTag("collider")){
           // AudioSource.PlayClipAtPoint(click, transform.position);
            //FindObjectOfType<AudioManager>().Play("collider");
        }
        
    }
    

    //Dealing the damage from enemy
    private void TakeDamage(int damage){
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);
        
    }
    
}