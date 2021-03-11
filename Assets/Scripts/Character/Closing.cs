using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closing : MonoBehaviour
{
    public GameObject SceneOne;
    public GameObject SceneTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClosingScenes()
    {
        SceneOne.SetActive(false);
        SceneTwo.SetActive(false);
    }
}
