using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesScript : MonoBehaviour
{
    public Text ShowLifes;
    int lifesCount;

    public void substractLifes()
    {
        --lifesCount;
        ShowLifes.text = lifesCount.ToString() + " lifes";
    }
    public void addLifes() { 
        ++lifesCount;
        ShowLifes.text = lifesCount.ToString() + " lifes";
    }
    void setLifes2() {
        lifesCount = 4;
        ShowLifes.text = lifesCount.ToString() + " lifes";
    }
    // Start is called before the first frame update
    void Start()
    {
        setLifes2();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) { Start(); }
        //UnityEngine.Debug.Log(lifesCount);
    }
    private void FixedUpdate()
    {
       // ShowLifes.text = lifesCount.ToString() + " lifes";
    }

}

