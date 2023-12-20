using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    Cell firstPiece;
    [SerializeField] Match3 board;
    int turn = 0;
    int score = 0;

    [SerializeField] Text scoreText;
    [SerializeField] Text turnText;
    [SerializeField] Text move;
    [SerializeField] Button Continue;

    // Start is called before the first frame update
    public void ClickPiece(Cell p)
    {
        if (enabled && turn < 5)
        {
            Continue.gameObject.SetActive(false);
            if (firstPiece == null)
            {
                firstPiece = p;
            }
            else
            {
                if (firstPiece == p)
                {
                    firstPiece = null;
                }
                else
                {
                    // First piece no es nulo y no es la misma pieza que clican
                    if (NextTo(firstPiece, p))
                    {
                        firstPiece.Switch(p);

                        if (!board.Turn(() => { enabled = true; }, AddScore))
                        {
                            firstPiece.Switch(p);
                            move.text="Not valid movement";
                        }
                        else
                        {
                            enabled = false;
                            NextTurn();
                            move.text = "Good moved";
                        }
                        firstPiece = null;
                    }
                    else
                    {
                        firstPiece = null;
                    }
                }
            }
        }
        else if(turn ==5)
        {
            Continue.gameObject.SetActive(true);
        }
    }
    public void EndMini()
    {
        PlayerInputManager.SetValidInput(true);
        TextingFile.Avite();
        SceneManager.UnloadSceneAsync(2);
    }

    public void TurnEnded()
    {
        enabled = true;
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = string.Format("{0:000000000}", this.score);
    }

    public void NextTurn()
    {
        ++turn;
        turnText.text = "Turnos: " + turn;
    }

    public bool NextTo(Cell firts, Cell second)
    {
        int distX = Mathf.Abs(firts.Col() - second.Col());
        int distY = Mathf.Abs(firts.Row() - second.Row());
        int dist = distX + distY;
        return dist == 1;
    }
}
