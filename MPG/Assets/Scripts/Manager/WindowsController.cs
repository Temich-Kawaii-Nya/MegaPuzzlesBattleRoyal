using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject PauseWindow;

    public void Resume()
    {
        gameState.SetState(GameStates.Gameplay);
        PauseWindow.SetActive(false);
    }
    private void Pause()
    {
        if (gameState.state == GameStates.Gameplay)
        {
            PauseWindow.SetActive(true);
        }
        else if (gameState.state == GameStates.Pause)
        {
            Resume();
        }
    }
}
