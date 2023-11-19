using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlesStat : MonoBehaviour
{
    private List<GameObject> pieces;
    private void Start()
    {
        pieces = new List<GameObject>();
    }

    public List<GameObject> GetPieces() { return pieces; }
    private void AddPiece(GameObject piece)
    {
        if(piece != null)
            pieces.Add(piece);
    }

    private void OnEnable()
    {
        PiesesGenerator.OnPieceCreated += AddPiece;
    }
    private void OnDisable()
    {
        PiesesGenerator.OnPieceCreated -= AddPiece;
    }
}
