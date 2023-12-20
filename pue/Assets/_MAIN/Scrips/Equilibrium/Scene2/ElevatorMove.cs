using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{

    Animator ElevatorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ElevatorAnimator = GetComponent<Animator>();
    }

   public void SetTrigger() {
        ElevatorAnimator.SetTrigger("IsBallThere");
    }

}
