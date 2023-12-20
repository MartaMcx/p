using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFall : MonoBehaviour
{
    public TrapKineticTrigger trapKineticReference;

    void KineticsOff() {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) { this.gameObject.SetActive(false); }

    }

    private void FixedUpdate()
    {
        
        if ( trapKineticReference.trapHasToFall) { KineticsOff(); }

    }
}
