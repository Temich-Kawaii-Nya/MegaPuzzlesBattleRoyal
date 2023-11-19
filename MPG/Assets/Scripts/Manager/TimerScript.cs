using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameState gameState;
    private int secondsPast;
    private WaitForSeconds wait = new WaitForSeconds(1f);

    private void Start()
    {
        SetDefault();
    }
    private void SecondsToTime()
    {
        int minute = secondsPast / 60;
        int seconds = secondsPast % 60;
        string str = $"{minute}:{seconds:D2}";
        timerText.text = str;
        Debug.Log(str);
        Debug.Log(secondsPast);
    }

    private void StartTimer()
    {
        if (gameState.state == GameStates.Gameplay)
        {
            StartCoroutine(Timer());
        }
    }

    private void StopTimer()
    {
        if (gameState.state == GameStates.GameFinishe)
        {
            StopCoroutine(Timer());
            SetDefault();
        }
        
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            if (gameState.state == GameStates.Gameplay)
            {
                yield return wait;
                secondsPast++;
                SecondsToTime();
            }
        }
    }

    private void SetDefault()
    {
        StopCoroutine(Timer());
        secondsPast = 0;
        SecondsToTime();
    }

    private void OnEnable()
    {
        Shuffle.OnShuffled += StartTimer;
    }
    private void OnDisable()
    {
        Shuffle.OnShuffled -= StartTimer;
    }



}
