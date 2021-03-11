using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)  // or if(gameObject.CompareTag("YourWallTag"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
