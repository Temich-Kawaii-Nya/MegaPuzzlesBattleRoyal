using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private PuzzlesStat puzzles;
    private List<GameObject> puzzlesList;

    public void AddPuzzles()
    {
        puzzlesList = puzzles.GetPieces();
    }
    private void ChangeOrder(GameObject current)
    {
        if (puzzlesList.Count > 0)
        {
            for (int i = 0; i < puzzlesList.Count; i++)
            {
                puzzlesList[i].GetComponent<SpriteRenderer>().sortingOrder--;
            }
            current.GetComponent<SpriteRenderer>().sortingOrder = puzzlesList.Count;
        }
    }
    private void SetRightPosiotionOrder(GameObject current)
    {
        current.GetComponent<SpriteRenderer>().sortingOrder = -100;
    }
    private void OnEnable()
    {
        PositionChecker.OnRightPos += SetRightPosiotionOrder;
        PlayerInput.IsPicked += ChangeOrder;
        PiesesGenerator.OnGenerationFinished += AddPuzzles;
    }
    private void OnDisable()
    {
        PositionChecker.OnRightPos -= SetRightPosiotionOrder;
        PlayerInput.IsPicked -= ChangeOrder;
        PiesesGenerator.OnGenerationFinished-= AddPuzzles;
    }
}
