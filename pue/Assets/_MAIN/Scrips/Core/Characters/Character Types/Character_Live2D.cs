using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Live2D : Character
{
    public Character_Live2D(string name, CharacterConfigData config) : base(name, config)
    {
        Debug.Log($"Create Live2D Character: '{name}'");
    }
}
