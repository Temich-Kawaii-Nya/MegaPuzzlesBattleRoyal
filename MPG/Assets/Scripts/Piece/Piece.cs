using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector2 _startPosition { get; private set; }
    public bool _isInRightPosition { get; set; }
    [SerializeField] private int score = 500;
    public bool _isScored { get; set; }
    public int order { get; set; }

    public int GetScore()
    {
        return score;
    }
    private void Start()
    {
        SetDefaultPositionsAndRotation();
    }

    private void SetDefaultPositionsAndRotation()
    {
        _startPosition = transform.position;
    }
}
