using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Test());
    }

    // Update is called once per frame
    IEnumerator Test()
    {
        Character Elena = CharacterManager.Instance().CreateCharacter("Elena");
        Character Adam = CharacterManager.Instance().CreateCharacter("Adam");
        Character Shara = CharacterManager.Instance().CreateCharacter("Shara");
        List<string> lines = new List<string>()
        {
            "Hola, qué tal?",
            "Mi nombre es Elena.",
            "¿Cual es tu nombre ?",
            "oh, {wa 1} Esta bien"
        };
        yield return Elena.Say(lines);
        lines = new List<string>()
        {
            "Soy Adam",
            "Más lines {c} aquí "
        };
        yield return Adam.Say(lines);

        yield return Shara.Say("Esta es una linea {a} de prueba.");
        Debug.Log("Final");
    }
}
