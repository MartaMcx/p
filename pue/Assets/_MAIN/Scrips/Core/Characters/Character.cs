using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Character 
{
    private string name = "";
    private string displayName = "";
    private RectTransform root=null;
    private CharacterConfigData config;

    protected Coroutine co_revealing, co_hiding;
    public bool IsReveling() {  return co_revealing != null; }
    public bool IsHiding() {  return co_hiding != null; }
    public virtual bool IsVible() { return false; }
    public Character(string name, CharacterConfigData config) 
    {
        this.name = name; 
        displayName = name;
        this.config = config;
    }
    public void SetRoot(RectTransform root) {  this.root = root; }
    public void SetConfig(CharacterConfigData config) {  this.config = config; }
    public string GetName() {  return name; }
    public RectTransform GetRoot() { return root;}
    public CharacterConfigData GetConfig() {  return config;}

    public Coroutine Say(string dialogue) {return Say(new List<string> { dialogue }); }
    public Coroutine Say(List<string> dialogue) 
    {
        DialogueSystem.Instance().ShowName(displayName);
        UpdateTextCustomizationOnScreem();
        return DialogueSystem.Instance().Say(dialogue);
    }
    public void SetDialogueColor(Color color) { config.SetDialogueColor(color); }
    public void SetNameColor(Color color) { config.SetNameColor(color); }
    public void SetDialogueFont(TMP_FontAsset font) { config.SetDialogueFront(font); }
    public void ResetConfigurationData() { config = CharacterManager.Instance().GetCharacterConfig(name); }
    public void UpdateTextCustomizationOnScreem() { DialogueSystem.Instance().ApplySpeakerDataToDialogueContainer(config); }
    public void SetNameFont(TMP_FontAsset font) { config.SetNameFront(font); }
    public virtual Coroutine Show()
    {
        return null;
    }
    public virtual Coroutine Hide()
    {
        return null;
    }
    public virtual IEnumerator ShowingOrHiding()
    {
        Debug.Log("Show/Hide cannot be called from a base character type.");
        return null;
    }
    public enum CharacterType { Text, Sprite, SpriteSheet, Live2D, Model3D }
}
