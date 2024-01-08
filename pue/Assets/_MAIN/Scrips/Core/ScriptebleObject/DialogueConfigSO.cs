using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueConfig", menuName = "Dialogue System/Dialogue Config Asset")]
public class DialogueConfigSO : ScriptableObject
{
    [SerializeField] private CharacterConfigSO characterConfigAsset;
    public CharacterConfigSO GetCharacterConfig() {return characterConfigAsset; }
    public Color DefaultTextColor() { return Color.white; }
    private TMP_FontAsset defaultFont;
    public TMP_FontAsset GetDefaultFontAsset() { return defaultFont; }
}
