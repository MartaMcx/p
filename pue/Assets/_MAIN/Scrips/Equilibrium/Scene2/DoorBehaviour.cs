using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public KeyBehaviour GetKeyBehaviour;

    private void FixedUpdate()
    {
        if (GetKeyBehaviour.isKeyGet) { this.gameObject.SetActive(false); }
    }
}
