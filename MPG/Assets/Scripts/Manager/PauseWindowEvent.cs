using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindowEvent : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject pauseButton;

    private void OnEnable()
    {
        pauseButton.SetActive(false);
        gameState.SetState(GameStates.Pause);
    }
    private void OnDisable()
    {
        pauseButton.SetActive(true);
    }
}
