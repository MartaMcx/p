using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    static bool validInput = true;
    public static void SetValidInput( bool valid)
    {
        validInput = valid; 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        { 
            PromptAdvance(); 
        }
        if(Input.mouseScrollDelta.y>0f && validInput)
        {
            BacklogPanel.Instance().Show();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    public void PromptAdvance()
    {
        if (validInput)
        {
            DialogueSystem.Instance().OnPressed();
        }

    }
}
