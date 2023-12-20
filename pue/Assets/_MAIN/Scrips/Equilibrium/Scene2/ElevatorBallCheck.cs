using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBallCheck : MonoBehaviour
{

    [SerializeField] ElevatorMove GetElevatorMove;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            GetElevatorMove.SetTrigger();
        }

    }
}
