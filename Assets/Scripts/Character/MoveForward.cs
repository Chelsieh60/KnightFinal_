using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{  public GameObject Player;
    public float speed = 40.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Player.transform.localRotation;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
