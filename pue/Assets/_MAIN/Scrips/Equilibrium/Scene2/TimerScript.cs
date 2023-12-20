using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    
    public bool TimerOn;

    [SerializeField] Text TimerText;
    [SerializeField] float TimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        TimeLeft = 80;
    }

    void showText() {
        TimerText.text = TimeLeft.ToString() + " Seconds";
    }

    void TimeIsUp() {
        TimerOn = false;
        TimerText.text = "TIME'S UP";
        TimeLeft = 0;
        

    }
    /*
    void updateTimer(float currentTime) {

        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

    }
    */

    // Update is called once per frame
    void Update()
    {
        if (TimeLeft > 0) { TimeLeft -= Time.deltaTime; showText(); }     
        else {
            TimeIsUp();
        }
        if (Input.GetButtonDown("Jump")) { Start(); }

        //UnityEngine.Debug.Log(TimerOn);
    }
}
