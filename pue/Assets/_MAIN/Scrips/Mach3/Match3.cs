using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Match3 : MonoBehaviour
{
    public delegate void Action();
    public delegate void MatchAction(int n);

    [SerializeField] PieceDB pieceDB;

    Cell[,] board;

    [SerializeField] int col;
    int row;

    private void Start()
    {
        // Get all the pieces
        Cell[] child = transform.GetComponentsInChildren<Cell>();

        // Calculate the row number
        row = child.Length / col;

        // Init the board with the pieces
        board = new Cell[row, col];

        for (int r = 0; r < row; ++r)
        {
            for (int c = 0; c < col; ++c)
            {
                board[r, c] = child[r * col + c];
                board[r, c].SetPositionOnBoard(r, c);
            }
        }

        //for (int i = 0; i < child.Length; ++i)
        //{
        //    int targetRow = i / col;
        //    int targetCol = i % col;
        //    board[targetRow, targetCol] = child[i];
        //}

        // Init the board with random values
        for (int r = 0; r < row; ++r)
        {
            for (int c = 0; c < col; ++c)
            {
                board[r, c].SetPiece(pieceDB.GetRandomPiece());
            }
        }

        // Start the board with no matches
        while (CheckMatches(DoNothing))
            BoardGravity();
    }

    public void DoNothing(int n)
    {

    }

    bool CheckMatches(MatchAction onMatch)
    {
        bool horizontal = CheckMatchesHorizontal(onMatch);
        bool vertical = CheckMatchesVertical(onMatch);
        return horizontal || vertical;
    }

    bool CheckMatchesVertical(MatchAction onMatch)
    {
        bool thereIsMatch = false;
        for (int c = 0; c < col; ++c)
        {
            int count = 1; // How many same pieces match
            Piece last = board[0, c].GetPiece(); // Type of piece

            for (int r = 1; r < row; ++r)
            {
                if (board[r, c].Is(last))
                {
                    ++count;
                }
                else
                {
                    if (count >= 3)
                    {
                        for (int i = r - 1; i >= r - count; --i)
                        {
                            onMatch(board[i, c].GetPiece().GetScore());
                            board[i, c].Clear();
                            thereIsMatch = true;
                        }
                    }
                    count = 1;
                    last = board[r, c].GetPiece();
                }
            }
            if (count >= 3)
            {
                for (int i = row - 1; i >= row - count; --i)
                {
                    onMatch(board[i, c].GetPiece().GetScore());
                    board[i, c].Clear();
                    thereIsMatch = true;
                }
            }
        }
        return thereIsMatch;
    }

    bool CheckMatchesHorizontal(MatchAction onMatch)
    {
        bool thereIsMatch = false;
        for (int r = 0; r < row; ++r)
        {
            int count = 1; // How many same pieces match
            Piece last = board[r, 0].GetPiece(); // Type of piece

            for (int c = 1; c < col; ++c)
            {
                // if (board[r, c].GetId() == last)
                if (board[r, c].Is(last))
                {
                    ++count;
                }
                else
                {
                    if (count >= 3)
                    {
                        for (int i = c - 1; i >= c - count; --i)
                        {
                            onMatch(board[r, i].GetPiece().GetScore());
                            board[r, i].Clear();
                            thereIsMatch = true;
                        }
                    }
                    count = 1;
                    last = board[r, c].GetPiece();
                }
            }
            if (count >= 3)
            {
                for (int i = col - 1; i >= col - count; --i)
                {
                    onMatch(board[r, i].GetPiece().GetScore());
                    board[r, i].Clear();
                    thereIsMatch = true;
                }
            }
        }
        return thereIsMatch;
    }

    void BoardGravity()
    {
        for (int r = row - 1; r >= 0; --r)
        {
            for (int c = 0; c < col; ++c)
            {
                if (board[r, c].IsEmpty())
                {
                    // See the not-null piece on top of it
                    int targetR = r - 1;
                    while (targetR >= 0 && board[targetR, c].IsEmpty())
                    {
                        --targetR;
                    }

                    if (targetR >= 0)
                    {
                        board[r, c].SetPiece(board[targetR, c]);
                        board[targetR, c].Clear();
                    }
                    else
                    {
                        board[r, c].SetPiece(pieceDB.GetRandomPiece());
                    }
                }
            }
        }
    }

    public bool Turn(Action onEnded, MatchAction onMatch)
    {
        if (!CheckMatches(onMatch)) return false;
        StartCoroutine(DoCheckTurn(onEnded, onMatch));
        return true;
    }

    IEnumerator DoCheckTurn(Action onEnded, MatchAction onMatch)
    {
        do
        {
            yield return new WaitForSeconds(2);
            BoardGravity();
            yield return new WaitForSeconds(2);
        }
        while (CheckMatches(onMatch));

        onEnded();
    }

}