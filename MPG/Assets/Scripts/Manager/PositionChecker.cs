using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChecker : MonoBehaviour
{
    [SerializeField] private GameState _state;
    [Space]
    [SerializeField] private float _snapOffset;

    public static event Action OnRightPosition;
    public static event Action<GameObject> OnRightPos;
    public static event Action<int> OnPlacedForFirstTime;

    private void CheckRightPosition(Piece piece)
    {
        if (_state.state == GameStates.Gameplay)
        {
            if ((Vector2.Distance(piece.transform.position, piece._startPosition) <= _snapOffset) && (Mathf.Abs(piece.transform.rotation.w) == 1))
            {
                piece.transform.position = piece._startPosition;
                piece._isInRightPosition = true;
                OnRightPosition?.Invoke();
                OnRightPos?.Invoke(piece.gameObject);
                if (!piece._isScored)
                {
                    OnPlacedForFirstTime?.Invoke(piece.GetScore());
                    piece._isScored = true;
                }
            }
            else
            {
                piece._isInRightPosition = false;
            }
        }
    }
    private void OnEnable()
    {
        PlayerInput.IsDroped += CheckRightPosition;
    }
    private void OnDisable()
    {
        PlayerInput.IsDroped -= CheckRightPosition;
    }
}
