using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class NameContainer 
{
    [SerializeField] private GameObject root;
    [SerializeField] private TextMeshProUGUI nameText;
    CanvasGroup can;
    [SerializeField] RectTransform tam;
    RectTransform tamChildren;
    public void Show(string naneToShow =" ")
    {
        can = root.GetComponent<CanvasGroup>();
        tam = root.GetComponent<RectTransform>();
        tamChildren = nameText.GetComponent<RectTransform>();
        can.alpha=1;

        if (naneToShow != string.Empty ) 
        {
            nameText.text = naneToShow;
            string[] names = nameText.text.Split(" ");
            if (naneToShow.Length < 10 || names.Length == 1)
            {
                tam.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, naneToShow.Length * 40);
                tamChildren.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, naneToShow.Length * 40);
            }
            else
            {
                int lent =0;
                for (int i = 0; i < names.Length; ++i)
                {
                    lent = Mathf.Max(names[i].Length, lent); ;
                }
                tamChildren.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lent * 20);
                tam.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lent * 50);
                tam.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, names.Length * 82);
                //tamChildren.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
            }
            //tam.rect.width = tam.rect.width * nameText.text.Length;
        }
    }
    public void Hide() 
    {
        can = root.GetComponent<CanvasGroup>();
        can.alpha = 0;
        //root.SetActive(false);
    }
    public void SetNameColor(Color color) { nameText.color = color; }
    public void SetNameFont(TMP_FontAsset font) {  nameText.font = font; }
}
