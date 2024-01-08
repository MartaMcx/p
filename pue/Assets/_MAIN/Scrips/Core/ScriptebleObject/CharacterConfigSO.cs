using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharConfig", menuName ="Dialogue System/Character Config Asset")]
public class CharacterConfigSO : ScriptableObject
{
    [SerializeField] CharacterConfigData[] characters;
    public CharacterConfigData GetConfig(string characterName)
    {
        characterName = characterName.ToLower();
        for (int i = 0; i < characters.Length; ++i) 
        {
            CharacterConfigData data = characters[i];
            if(string.Equals(characterName,data.GetName().ToLower()) || string.Equals(characterName,data.GetAlias().ToLower()))
            {
                return data.Copy();
            }
        }
        return CharacterConfigData.Default;
    }
}
