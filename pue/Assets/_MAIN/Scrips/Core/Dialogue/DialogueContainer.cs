using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueContainer
{
    [SerializeField] private GameObject root;
    [SerializeField] private NameContainer nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private CanvasGroupController cgController;

    public void SetDialogueColor(Color color) { dialogueText.color = color; }
    public void SetDialogueFont(TMP_FontAsset font){ dialogueText.font = font; }
    public GameObject GetRoot() {  return root; }
    public NameContainer GetNameContainer(){ return nameText; }
    public TextMeshProUGUI GetDialogueText(){ return dialogueText; }
    private bool initialized=false;
    public void Initialize()
    {
        if (initialized) 
        { return; }

        cgController = new CanvasGroupController(DialogueSystem.Instance(), root.GetComponent<CanvasGroup>());
    }
    public bool isVisible() { return cgController.isVisible(); }
    public Coroutine Show() { return cgController.Show(); }
    public Coroutine Hide() { return cgController.Hide(); }
}
