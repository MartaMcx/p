using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows;

public class InputPanel : MonoBehaviour 
{
    [SerializeField] private Button backButton;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Button acceptButton;
    [SerializeField] private TMP_InputField inputField;
    static InputPanel instance=null;
    public static InputPanel Instance() { return instance; }
    private string lastInput;
    public string getLastInput() { return lastInput; }
    private bool isWaitingOnUserInput;
    public bool getIsWaitingOnUserInput() {return isWaitingOnUserInput; }
    private CanvasGroupController cg;
    void Start()
    {
        cg= new CanvasGroupController(this, canvasGroup);
        cg.setAlpha(0);
        cg.SetInteractiveState(active: false);
        acceptButton.gameObject.SetActive(false);
        inputField.onValueChanged.AddListener(OnInputCharged); 
        acceptButton.onClick.AddListener(OnAcceptInput);
    }
    private void Awake()
    {
       instance = this;
    }
    public void Show(string title)
    {
        backButton.interactable = false;
        titleText.text = title;
        Debug.Log(title);
        inputField.text = string.Empty;
        cg.Show();
        isWaitingOnUserInput = true;
        cg.SetInteractiveState(active: true);
        inputField.Select();
    }
    public void Hide()
    {
        backButton.interactable = true;
        cg.Hide();
        isWaitingOnUserInput= false;
        cg.SetInteractiveState(active: false);
    }
    public void OnAcceptInput()
    {
        if(!HasValirText())
        {
            return;
        }
        lastInput= inputField.text;
        Hide();
    }
    public void OnInputCharged(string value)
    {
        acceptButton.gameObject.SetActive(HasValirText());
    }
    public void OnSelected()
    {
        Debug.Log("Selecionado");
    }
    private bool HasValirText()
    {
        string val = inputField.text;
        if (val.Contains('@')){ val = val.Replace("@",""); }
        if (val.Contains('#')) { val = val.Replace("#", ""); }
        if (val.Contains('.')) { val = val.Replace(".", ""); }
        if (val.Contains('%')) { val = val.Replace("%", ""); }
        if (val.Contains('&')) { val = val.Replace("&", ""); }
        if (val.Contains('"')) { val = val.Replace("\"", ""); }
        if (val.Contains('\'')) { val = val.Replace("'", ""); }
        if (val.Contains('$')) { val = val.Replace("$", ""); }
        if (val.Contains('/')) { val = val.Replace("/", ""); }
        if (val.Contains('(')) { val = val.Replace("(", ""); }
        if (val.Contains(')')) { val = val.Replace(")", ""); }

        if (val == string.Empty || string.IsNullOrWhiteSpace(val)|| val.Length < 3 && inputField.text.Length < 30)
        {  return false; }
        return true;     
    }
}
