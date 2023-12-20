using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChange2 : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //SceneManager.LoadScene(3, LoadSceneMode.Additive);
            PlayerInputManager.SetValidInput(true);
            TextingFile.Avite();
            SceneManager.UnloadSceneAsync(1);

            //TextingFile.val=SceneManager.LoadSceneAsync("Dialogue");
            /*
            if (SceneManager.UnloadSceneAsync(01).isDone)
            {

                GameObject PlayerInputManager = UnityEngine.Object.FindFirstObjectByType<PlayerInputManager>().gameObject;
                PlayerInputManager.GetComponent<PlayerInputManager>().SetValidInput(true);
            }
            */
        }

    }

}
