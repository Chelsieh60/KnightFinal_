using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void pausinggame(){
      
        menuScene.SetActive(false);
    }
       
}
