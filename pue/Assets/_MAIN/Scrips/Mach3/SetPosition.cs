using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetPosition : MonoBehaviour
{
    public delegate void Event(float f);
    event Event onValueChanged;

    public void Start()
    {
        Slider s = GetComponent<Slider>();

        onValueChanged += SetPositionX;
    }
    public void SetPositionX(float num)
    {
        transform.position = new Vector3(num, 0, 0);
    }
}