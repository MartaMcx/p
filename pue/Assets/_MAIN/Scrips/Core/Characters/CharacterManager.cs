using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    static CharacterManager instance;
    public static CharacterManager Instance() { return instance; }
    private Dictionary<string, Character> characters =new Dictionary<string, Character>();
    private CharacterConfigSO config =>DialogueSystem.Instance().GetConfig().GetCharacterConfig();
    private void Awake()
    {
        instance = this;
    }
    public CharacterConfigData GetCharacterConfig(string characterName) 
    {
        return config.GetConfig(characterName);
    }
    public Character GetCharacter(string characteName,bool createIfnotExist=false)
    {
        if(characters.ContainsKey(characteName.ToLower()))
        {
            return characters[characteName.ToLower()];
        }
        else if (createIfnotExist)
        { 
            return CreateCharacter(characteName);
        }
        return null;
    }
    public Character CreateCharacter(string characterName)
    {
        if(characters.ContainsKey(characterName.ToLower())) 
        {
            Debug.LogWarning($"A Character called '{characterName}' already exists. Did not create the character.");
            return null;
        }
        CHARACTER_INFO info = GerCharacterInfo(characterName);
        
        Character character = CreateCharacterFormInfo(info);
        characters.Add(characterName.ToLower(), character);
        return character;
    }
    private CHARACTER_INFO GerCharacterInfo(string characterName)
    {
        CHARACTER_INFO result = new CHARACTER_INFO();
        result.SetName(characterName);
        result.SetConfig(config.GetConfig(characterName));
        return result;
    }
    private Character CreateCharacterFormInfo(CHARACTER_INFO info)
    {
        CharacterConfigData config = info.GetConfig();
        if(config.GetCharcterType()== Character.CharacterType.Text)
        {
            return new Character_Text(info.GetName(), config);
        }
        if (config.GetCharcterType() == Character.CharacterType.Sprite || config.GetCharcterType() == Character.CharacterType.SpriteSheet)
        {
            return new Character_Sprite(info.GetName(), config);
        }
        if (config.GetCharcterType() == Character.CharacterType.Live2D)
        {
            return new Character_Live2D(info.GetName(), config);
        }
        if (config.GetCharcterType() == Character.CharacterType.Model3D)
        {
            return new Character_Model3D(info.GetName(), config);
        }
        return null;
    }
    private class CHARACTER_INFO
    {
        private string name= "";
        private CharacterConfigData config = null;

        public void SetName(string name) { this.name = name; }
        public void SetConfig(CharacterConfigData config) {  this.config = config; }
        public string GetName() { return name; }
        public CharacterConfigData GetConfig() { return config; }
    }
}
