using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public LifesScript GetLifesScript;
    public TimerScript GetTimerScript;
    int playerLifes;
    Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0.5f);

    void Start()
    {
        playerLifes = 4;
        ResetBall();
    }

    void ResetBall() {

        //reset position
        gameObject.GetComponent<Transform>().position = new Vector3 (25.22f, 10.44f, -5.25f);
        gameObject.SetActive(true);

        //reset velocity
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            --playerLifes;
            GetLifesScript.substractLifes();
        }

        if (collision.gameObject.CompareTag("DeadZone"))
        {
            --playerLifes;
            GetLifesScript.substractLifes();
            ResetBall();
        }

        if (collision.gameObject.CompareTag("LifeUP"))
        {
            ++playerLifes;
            GetLifesScript.addLifes();
        }

        if (collision.gameObject.CompareTag("BluePotion"))
        {
            gameObject.GetComponent<Transform>().localScale = scaleChange;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            --playerLifes;
            GetLifesScript.substractLifes();

        }
        /*
        if (collision.gameObject.CompareTag("LifeUP"))
        {
            ++playerLifes;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Start();
        }
    }

    private void FixedUpdate()
    {

        //GameOver Conditions
        if (playerLifes < 0) { /*this.gameObject.SetActive(false);*/ 
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (GetTimerScript.TimerOn == false) { gameObject.SetActive(false); }

    }
}
