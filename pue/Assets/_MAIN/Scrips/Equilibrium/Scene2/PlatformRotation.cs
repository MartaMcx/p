using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformRotation : MonoBehaviour
{

    [SerializeField] float speedPlatform2;

    void Start()
    {
        speedPlatform2 = 12.5f;
    }

    void left()
    {
        //transform.Rotate(0, 0, speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, speedPlatform2) * Time.deltaTime);

    }
    void right()
    {
        //transform.Rotate(0, 0, (speed*-1) * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, (speedPlatform2 * -1)) * Time.deltaTime);
    }
    void forward()
    {
        //transform.Rotate(0, 0, (speed*-1) * Time.deltaTime);
        transform.Rotate(new Vector3(speedPlatform2, 0, 0) * Time.deltaTime);
    }
    void backward()
    {
        //transform.Rotate(0, 0, (speed*-1) * Time.deltaTime);
        transform.Rotate(new Vector3((speedPlatform2 * -1), 0, 0) * Time.deltaTime);
    }

    void platformRestart() {
        transform.position = new Vector3(35.7f, 7f, 5.08f);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) { left(); }
        if (Input.GetKey(KeyCode.D)) { right(); }
        if (Input.GetKey(KeyCode.W)) { forward(); }
        if (Input.GetKey(KeyCode.S)) { backward(); }
        if (Input.GetButtonDown("Jump")) { 
            platformRestart();
            GameObject Ball = GameObject.FindWithTag("Ball");
            //if (Ball == null) { Ball.gameObject.SetActive(true); }
            Ball.gameObject.GetComponent<MeshRenderer>().enabled = true;
            Ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Transform BallTransform = GameObject.FindWithTag("Ball").transform;
            BallTransform.position = new Vector3(25.22f, 10.44f, -5.25f);
        }
        /*if (Input.GetKey("r")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }*/
    }

}
