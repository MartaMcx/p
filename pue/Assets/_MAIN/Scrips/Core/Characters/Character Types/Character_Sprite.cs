using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Sprite : Character
{
    public Character_Sprite(string name, CharacterConfigData config) : base(name, config)
    {
        Debug.Log($"Create Sprite Character: '{name}'");
    }
}
