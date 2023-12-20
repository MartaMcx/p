using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] int scene;
    public void change()
    {
        SceneManager.LoadScene(scene);
    }
}
