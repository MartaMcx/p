using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingButtonFunction : MonoBehaviour
{
    public void MyFunct(GameObject yoshi)
    {
        yoshi.SetActive(!yoshi.activeSelf);
    }
}
