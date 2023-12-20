using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {  this.gameObject.SetActive(false); }

    }
}
