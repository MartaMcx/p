using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWeakBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
