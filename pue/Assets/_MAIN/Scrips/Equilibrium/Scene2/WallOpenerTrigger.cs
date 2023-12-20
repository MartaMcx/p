using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpenerTrigger : MonoBehaviour
{

    public bool wallHasToRotate;
    // Start is called before the first frame update
    void Start()
    {
        wallHasToRotate = false;
    }

    /*
    private static WallOpenerTrigger instance;
    public static WallOpenerTrigger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<WallOpenerTrigger>();
            }
            return instance;
        }
    }
    */

    private void OnTriggerEnter(Collider collision)
    {

        
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            // WallOpenerRotation.Instance.WallRotate();
            wallHasToRotate = true;

        }
        
    }
    

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            WallOpenerRotation.Instance.WallRotate();
        }

    }
    */

    /*
    void OnCollisionEnter(Collision collision)
    {

        //  winning ball;
        //  ball = collision.gameObject.GetComponent<winning>();
        // si choca con un objeto que no tenga componente <winning> (por ahora solo tiene la bola), entonces ball recibe un valor nulo.
        // if (ball != null){
        //  ball.Restart();
        //
        // }


        ///////**collision.transform.position = new Vector3(1, 3.14f, 1);
        //--lifes;
        //Debug.Log ("Vidas: " +lifes)

        // if (lifes > 0) {
        //collision.transform.position = new Vector3(1, 3.14f, 1);
        //--lifes;
        //Debug.Log("Vidas: " +lifes);
        //
        //
        // }
    }


    */


    // Update is called once per frame
    void Update()
    {
        
    }
}
