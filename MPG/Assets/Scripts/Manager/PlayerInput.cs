using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private OrderManager orderManager;
    private PieceControl input;

    private int n;

    private Vector2 mousePos;

    private bool isDragging;
    public static event Action<Piece> IsDroped;
    public static event Action<GameObject> IsPicked;

    private void Awake()
    {
        input = new PieceControl();
        input.Enable();
    }

    private void movePieces(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        RaycastHit2D hit;
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0)), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.TryGetComponent<IControllable>(out IControllable piece))
            {
            IsPicked?.Invoke(hit.transform.gameObject);
                StartCoroutine(Drag(piece));
            }
    }
    private void Update()
    {
        ReadMousePosition();
    }

    private void ReadMousePosition()
    {
        mousePos = input.PlayerInput.MousePos.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        input.PlayerInput.Click.performed += movePieces;
        input.PlayerInput.Click.canceled += _ => { isDragging = false; };
        input.PlayerInput.Rotate.performed += RotateOnPerformed;
    }
    private void OnDisable()
    {
        input.PlayerInput.Click.performed -= movePieces;
        input.PlayerInput.Rotate.performed -= RotateOnPerformed;
    }

    private void RotateOnPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0)), Vector2.zero);
        if (hit.collider != null && hit.transform.gameObject.TryGetComponent<IControllable>(out IControllable piece))
        {
            piece.RotatePiece();
        }
    }
    private IEnumerator Drag(IControllable controllable)
    {
        isDragging = true;
        while (isDragging)
        {
            controllable.MovePiece(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0)));
            yield return null;
        }
        IsDroped?.Invoke((controllable as PieceController).gameObject.GetComponent<Piece>());
    }
}
