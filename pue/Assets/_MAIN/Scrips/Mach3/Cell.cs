using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour, IPointerClickHandler
{
    Image image;
    Piece piece;

    PlayerInput play;

    int row;
    int col;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        play = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }

    public void SetPiece(Piece piece)
    {
        this.piece = piece;
        if (piece != null)
        {
            image.color = piece.getColor();
        }
        else
        {
            image.color = new Color(0, 0, 0, 0);
        }
        
    }

    public void SetPiece(Cell other)
    {
        SetPiece(other.piece);
    }

    public bool IsEmpty()
    {
        return piece == null;
    }

    public void Clear()
    {
        SetPiece((Piece)null);
    }

    public Piece GetPiece()
    {
        return piece;
    }

    public bool Is(Piece id)
    {
        return piece == id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        play.ClickPiece(this);
    }

    public void Switch(Cell p2)
    {
        Piece aux = p2.piece;
        p2.SetPiece(piece);
        this.SetPiece(aux);
    }

    public void SetPositionOnBoard(int r, int c)
    {
        row = r;
        col = c;
    }

    public int Row() { return row; }
    public int Col() { return col; }
}