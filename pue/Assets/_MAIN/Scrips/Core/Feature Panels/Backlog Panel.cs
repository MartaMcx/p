using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BacklogPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button autoButton;
    [SerializeField] private Button skipButton;
    [SerializeField] private Button hideButton;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Scrollbar scrollbar;
    private List<string> text= new List<string>();
    public void SetTest(List<string> text) { this.text = text; }
    private int nLine = 0;
    public void PutInTest(string line) 
    { 
        text.Add(ReplaceText(line));
        string charLine=text[text.Count-1];
        nLine += (charLine.Length / 70);
        if (nLine > 4)
        {
            Text.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, nLine * 150);
        }
    }
    private string ReplaceText(string text)
    {
        text = TagManager.Inject(text);
        if(text.Contains("{a}"))
        {
            text = text.Replace("{a}", "");
        }
        if (text.Contains("{c}"))
        {
            text = text.Replace("{c}", "\n");
        }
        if (text.Contains(@"{wa \s\d*\.?\d*\}")) 
        {
            text = text.Replace(@"{wa \s\d*\.?\d*\}", "");
        }
        if (text.Contains(@"{wc \s\d*\.?\d*\}"))
        {
            text = text.Replace(@"{wc \\s\\d*\\.?\\d*\\}", "\n");
        }
        return text;
    }
    private CanvasGroupController cg;
    static BacklogPanel instance = null;
    public static BacklogPanel Instance() { return instance; }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        text = new List<string>();
        Text.text=string.Empty;
        cg = new CanvasGroupController(this, canvasGroup);
        cg.setAlpha(0);
        cg.SetInteractiveState(active: false);
        exitButton.gameObject.SetActive(false);
        exitButton.onClick.AddListener(Hide);
    }
    public void Show()
    {
        Text.text = string.Empty;
        for (int i=0; i< text.Count;++i )
        {
            Text.text += "\n \n" + text[i];
           // Text.gameObject.
        }
        if(!cg.isVisible())
        {
            scrollbar.value = 0;
        }
        cg.Show();
        exitButton.gameObject.SetActive(true);
        autoButton.interactable = false;
        skipButton.interactable = false;
        hideButton.interactable = false;
        cg.SetInteractiveState(active: true);
    }
    public void Hide()
    {
        autoButton.interactable = true;
        skipButton.interactable = true;
        hideButton.interactable = true;
        cg.Hide();
        cg.SetInteractiveState(active: false);
    }
}
