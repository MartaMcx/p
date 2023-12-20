using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O1 : MonoBehaviour
{

    [SerializeField] GameObject g;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            TestParams();
            TestParams(1);
            TestParams(1,2);
            TestParams(1,2,3);
            TestParams(1,2,3,4);
            int[] inputArray = new int[] { 1, 2, 3, 4, 5, 6 };
            TestParams(inputArray);
        }
    }

    void TestParams(params int[] enter)
    {
        for (int i = 0; i< enter.Length; ++i)
        {
            Debug.Log("Enter: " + enter[i]);
        }
    }

    void Hola(string message)
    {
        Debug.Log("Mensaje recibido: " + message);
    }

    void Hola(int i)
    {
        Debug.Log("Test");
    }
}
