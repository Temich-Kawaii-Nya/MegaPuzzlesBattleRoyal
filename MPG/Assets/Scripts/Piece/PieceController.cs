using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour, IControllable
{
    public void MovePiece(Vector2 position)
    {
        transform.position = position;
    }

    public void RotatePiece()
    {
        //transform.Rotate(0, 0, 90);
        transform.rotation *= Quaternion.Euler(0, 0, -90);
    }
}
