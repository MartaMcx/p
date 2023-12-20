using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapKineticTrigger : MonoBehaviour
{

    public bool trapHasToFall;

    void Start()
    {
        trapHasToFall = false;
    }

    private void OnTriggerEnter(Collider collision)
    {



        if (collision.gameObject.CompareTag("Ball"))
        {
            // WallOpenerRotation.Instance.WallRotate();
            trapHasToFall = true;

        }

    }
}
