using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUPBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball")) { this.gameObject.SetActive(false); }

    }

}
