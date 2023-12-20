using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallOpenerRotation : MonoBehaviour
{

    float rotationPivotSpeed = 5f;
    Quaternion rotationLimit = Quaternion.Euler (90, 0, 90);

    public WallOpenerTrigger doRotate;

    void Start()
    {
        //rotationDone = false;
    }
    /*
    private static WallOpenerRotation instance;
    public static WallOpenerRotation Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<WallOpenerRotation>();
            }
            return instance;
        }
    }
    */
    public void WallRotate() {
        //Quaternion rotationZ = Quaternion.Euler(transform.rotation.eulerAngles);
        //transform.localRotation.eulerAngles.z
        //transform.rotation.eulerAngles.z
        //Quaternion rotationCurrent = transform.rotation.z;
        //this.gameObject.GetComponent<Transform>().localRotation != rotationLimit
        //(objectRotation != rotationLimit)

        Quaternion objectRotation = transform.localRotation;

        if (gameObject.GetComponent<Transform>().localRotation != rotationLimit)
        {
            transform.Rotate(new Vector3(0, 0, (rotationPivotSpeed)) * Time.deltaTime);

        }
        //else {  = true; }

        //if (WallOpenerTrigger.GetComponent<wallHasToRotate> = "true") { }

        //UnityEngine.Debug.Log(transform.rotation.eulerAngles.z);
    }

    private void FixedUpdate()
    {
        
        if (doRotate.wallHasToRotate)
        {
            WallRotate();
            //UnityEngine.Debug.Log("yes");
        }

    }
}
