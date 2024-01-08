using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextingFile : MonoBehaviour
{
    [SerializeField] TextAsset fileToRead;
    [SerializeField] EventSystem eventSis;

    static EventSystem e;
    /*static Conversation c;
    static int p =0;
    public static void SaveData(Conversation co, int po)
    {
        c = co;
        p = po;
    }*/
    //[SerializeField] TextArchitect.BuildMethod ls = TextArchitect.BuildMethod.typewriter;
    void Start()
    {
        e = eventSis;
        DontDestroyOnLoad(this);
        VariableStore.CreateVariable("$player.myName", "");
        StartConversation(fileToRead);
    }
     void StartConversation(TextAsset fileToRead)
    {
        List<string> lines = FileManager.ReadTextAsset(fileToRead);
        DialogueSystem.Instance().Say(lines);
    }
    public static void Desvite()
    {
         e.gameObject.SetActive(false);
        
    }
    public static void Avite()
    {
        e.gameObject.SetActive(true);

    }
    /*
    public static AsyncOperation val = null;
    public static void SetValue()
    {
        Debug.Log(p);
        DialogueSystem.Instance().Say(c);
        DialogueSystem.Instance().GetConversationManager().GetConvesation().SetProgress(p+3);
    }*/
}
//Testing the Dialogue Marks and Dialogue Segmentation
/*
foreach (string line in lines)
{
    if (string.IsNullOrEmpty(line)) 
        return;


    Debug.Log($"Segmenting Line '{line}'");
    DIALOGUE_LINE dialogueLine = DialogueParser.ParseMethod(line);
    int i = 0;
    foreach (DIALOGUE_SEGMENT segment in dialogueLine.GetDialogue().GetDialogueSegments()) {

        Debug.Log($"Segment [{++i}] = '{segment.GetSegmentDialogue()}' [Mark={segment.GetDialogueMark()} {(segment.GetSignalWaitDelay() > 0 ? $"{segment.GetSignalWaitDelay()}" : $"")}]");

    }



}
*/