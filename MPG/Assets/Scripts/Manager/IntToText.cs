using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntToText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public void SetInt(int value)
    {
        text.text = value.ToString();
    }
}
