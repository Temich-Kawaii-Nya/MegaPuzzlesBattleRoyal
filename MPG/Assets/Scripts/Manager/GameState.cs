using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameStates state { get; private set; }
    public void SetState(GameStates state)
    {
        this.state = state;
        if (this.state == GameStates.Pause)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1; 
    }
}
public enum GameStates
{
    Pause,
    WaitingForStart,
    Gameplay,
    GameFinishe
}
