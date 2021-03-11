using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInv : MonoBehaviour
{
    public GameObject Inventoryscene;
    //public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Showinginv(){

            //inventory screen is open
            Inventoryscene.SetActive(true);
         }
    
}
