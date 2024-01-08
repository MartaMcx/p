using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Text : Character
{
    public Character_Text(string name, CharacterConfigData config): base(name,config)
    {
        Debug.Log($"Create Text Character: '{name}'");
    }
}
