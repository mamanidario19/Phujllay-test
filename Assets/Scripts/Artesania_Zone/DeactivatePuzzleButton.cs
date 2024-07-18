using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactivatePuzzleButton : MonoBehaviour
{
    public PuzzlePaintInteraction puzzleInteraction;

    public void OnClick()
    {
        puzzleInteraction.InteractOffPaint();
    }
}