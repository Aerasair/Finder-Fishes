using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private Outline _outline;

    public void ShowOutLine()
    {
        _outline.OutlineWidth = 10f;
    }

    public void HideOutLine()
    {
        _outline.OutlineWidth = 0f;
    }

}
