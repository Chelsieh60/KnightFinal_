using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decline : MonoBehaviour
{
    public GameObject NotSure;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeclineSure(){
        NotSure.SetActive(false);
    }
}
