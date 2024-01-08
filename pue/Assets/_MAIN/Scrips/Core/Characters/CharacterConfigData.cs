using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[System.Serializable]
public class CharacterConfigData 
{
    [SerializeField]private string name;
    [SerializeField]private string alias;
    [SerializeField]private Character.CharacterType charcterType;
    [SerializeField]private Color nameColor;
    [SerializeField]private Color dialogueColor;
    [SerializeField]private TMP_FontAsset nameFront;
    [SerializeField]private TMP_FontAsset dialogueFront;
    /*
    public void SetName(string name) { this.name = name; }
    public void SetAlias(string alias) { this.alias = alias; }
    public void SetCharcterType(Character.CharcterType charcterType) { this.charcterType = charcterType; }
    */
    public void SetNameColor(Color nameColor) { this.nameColor = nameColor; }
    public void SetDialogueColor(Color dialogueColor) { this.dialogueColor = dialogueColor; }
    public void SetNameFront(TMP_FontAsset nameFront) { this.nameFront = nameFront; }
    public void SetDialogueFront(TMP_FontAsset dialogueFront) { this.dialogueFront = dialogueFront; }
    public Character.CharacterType GetCharcterType() {return charcterType; }
    public string GetName() {  return name; }
    public string GetAlias() { return alias; }
    public Color GetNameColor() {  return nameColor; }
    public Color GetDialogueColor() {  return dialogueColor; }
    public TMP_FontAsset GetNameFont() {  return nameFront; }
    public TMP_FontAsset GetDialogueFont() {  return dialogueFront; }

    public CharacterConfigData Copy()
    {
        CharacterConfigData result = new CharacterConfigData();
        result.name = name;
        result.alias = alias;
        result.charcterType = charcterType;
        result.nameFront = nameFront;
        result.dialogueFront = dialogueFront;

        result.nameColor = new Color(nameColor.r, nameColor.g, nameColor.b, nameColor.a);
        result.dialogueColor = new Color(dialogueColor.r, dialogueColor.g, dialogueColor.b, dialogueColor.a);

        return result;
    }

    private static Color DefaultColor() { return DialogueSystem.Instance().GetConfig().DefaultTextColor(); }
    private static TMP_FontAsset DefaultFont() {return DialogueSystem.Instance().GetConfig().GetDefaultFontAsset(); }
    public static CharacterConfigData Default
    {
        get 
        {
            CharacterConfigData result = new CharacterConfigData();
            result.name = "";
            result.alias = "";
            result.charcterType = Character.CharacterType.Text;
            result.nameFront = DefaultFont();
            result.dialogueFront = DefaultFont();

            result.nameColor = new Color(DefaultColor().r, DefaultColor().g, DefaultColor().b, DefaultColor().a);
            result.dialogueColor = new Color(DefaultColor().r, DefaultColor().g, DefaultColor().b, DefaultColor().a);

            return result;
        }
    }
}
