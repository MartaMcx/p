using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour 
{
    public bool isKeyGet;
    // Start is called before the first frame update
    void Start()
    {
        isKeyGet = false;
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball")) { isKeyGet = true; this.gameObject.SetActive(false); }

    }

}
