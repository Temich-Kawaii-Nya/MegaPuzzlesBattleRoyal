using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int score;
    [SerializeField] private GameState gameState;
    [SerializeField] private UnityEvent<int> UIUpdate;

    private void Start()
    {
        SetDefault();
    }
    private void SetDefault()
    {
        score = 0;
        UIUpdate.Invoke(score);
    }
    private int GetScore()
    {
        return score;
    }
    private void ScoreCollect(int value)
    {
        if(gameState.state == GameStates.Gameplay)
        {
            score += value;
            UIUpdate.Invoke(score);
        }
    }
    private void OnEnable()
    {
        PositionChecker.OnPlacedForFirstTime += ScoreCollect;
    }
    private void OnDisable()
    {
        PositionChecker.OnPlacedForFirstTime -= ScoreCollect;
    }
}
