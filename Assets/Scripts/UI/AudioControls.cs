using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControls : MonoBehaviour
{
    public AudioClip clip;
   private AudioSource audioSource;
    public GameObject mainCam;
    public GameObject Player;
    public bool music = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player") && music == true){
            audioSource = other.gameObject.GetComponent<AudioSource>();
            music = false;
            //audioSource.clip = clip;
            audioSource.PlayOneShot(clip);
            //transform.parent = Player.transform;
            //AudioSource.PlayClipAtPoint(clip, Player.transform.position); //new Vector3(0,0,0));
            //FindObjectOfType<AudioManager>().Play("collider");
        }
        /*if (gameObject.CompareTag("Start") && other.gameObject.CompareTag("player") && music == true){
            audioSource = other.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(clip);
            Destroy(audioSource);
            Destroy(gameObject);
        }*/
        else if (other.gameObject.CompareTag("Player") && music == false){
            music = true;
            audioSource = other.gameObject.GetComponent<AudioSource>();
            audioSource.Stop();
        }
        
    }
}
