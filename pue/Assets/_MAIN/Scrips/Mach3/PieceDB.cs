using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[CreateAssetMenu(fileName = "PieceDB", menuName = "Piece", order = 5)]
public class PieceDB : ScriptableObject
{
    [SerializeField] Piece[] pieces;

    public int GetCount() { return pieces.Length; }

    public Piece GetPiece(int i) { return pieces[i]; }

    public Piece GetRandomPiece()
    {
        int newPiece = Random.Range(0, pieces.Length - 1);
        return pieces[newPiece];

    }
}

[Serializable]
public class Piece
{
    public enum PieceType { magenta = 1, cyan = 2, yellow, red, green }

    [SerializeField] PieceType type;
    [SerializeField] int score;

    static Color[] colors = new Color[] {
        new Color(0,0,0,0), Color.magenta, Color.cyan, Color.yellow, Color.red, Color.green};

    public Color getColor() { return colors[(int)type]; }
    public int GetScore() { return score; }
}
