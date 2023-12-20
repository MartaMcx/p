using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform ShpereTransform;
    //[SerializeField] private GameObject Shpere;
    [SerializeField] private Transform CubeTransform;
    [SerializeField] private Transform WinTransform;
    //private int winscore;
    //private int lifes;
    // Start is called before the first frame update

    public void GameManagerRestart() {
        ShpereTransform.position = new Vector3(1, 3.14f, 1);
        CubeTransform.rotation = new Quaternion(0, 0, 0, 0);
        //WinTransform.position = new Vector3(-0.113f, 5.3f, -0.154f);
    }
    private static GameManager instance;
    public static GameManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();
            }
        return instance;
        }
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("space")) { GameManagerRestart(); }
        //UnityEngine.Debug.Log(winscore + "score");
    }
}
