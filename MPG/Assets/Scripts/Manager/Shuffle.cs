using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shuffle : MonoBehaviour
{
    [SerializeField] private PuzzlesStat puzzles;
    [SerializeField] private float shuffleTime = 0.3f;
    [SerializeField] private GameState gameState;
    public static event Action OnShuffled;
    public void ShuffleBoard()
    {
        StartCoroutine(ShuffleCor());
    }
    public IEnumerator ShuffleCor()
    {
        List<GameObject> puzzleList = puzzles.GetPieces();
        float time = shuffleTime / puzzleList.Count;
        for (int i = 0; i < puzzleList.Count; i++)
        {
            puzzleList[i].transform.position = new Vector3(Random.Range(-6, 6), Random.Range(0, -6), 0);
            puzzleList[i].transform.rotation =Quaternion.Euler(new Vector3(0, 0, 90 * Mathf.RoundToInt(Random.Range(0, 4))));
            puzzleList[i].GetComponent<SpriteRenderer>().sortingOrder = i;
            yield return new WaitForSeconds(time);
        }
        gameState.SetState(GameStates.Gameplay);
        OnShuffled?.Invoke();
    }
}
