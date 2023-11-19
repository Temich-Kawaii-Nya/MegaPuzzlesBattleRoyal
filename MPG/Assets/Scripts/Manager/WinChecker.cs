using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    [SerializeField] private PuzzlesStat puzzles;
    private List<GameObject> pieces;

    private void SetPuzzles()
    {
        pieces = puzzles.GetPieces();
    }
    private void CheckWin()
    {
        bool f = false;
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].TryGetComponent(out Piece piece))
            {
                if (!piece._isInRightPosition)
                {
                    f = true;
                    break;
                }
            }
        }
        if (!f)
        {
            Debug.Log("WIN!");
        }
    }
    private void OnEnable()
    {
        PositionChecker.OnRightPosition += CheckWin;
        Shuffle.OnShuffled += SetPuzzles;
    }
    private void OnDisable()
    {
        PositionChecker.OnRightPosition -= CheckWin;
        Shuffle.OnShuffled -= SetPuzzles;
    }
}
