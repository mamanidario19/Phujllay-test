using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomboPuzzleManager : MonoBehaviour
{
    public AuthorizePlayPuzzle authorizePlayPuzzle; // Referencia a la clase AuthorizePlayPuzzle
    public GeneratePattern generatePattern; // Referencia a la clase GeneratePattern
    public BomboAnimation bomboAnimation; // Referencia a la clase BomboAnimation
    public bool isPlaying = false;
    public int aciertos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (authorizePlayPuzzle.thisObjectActive)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                isPlaying = true;
                aciertos = 0;
                // Inicializa la lista de objetos y asigna índices
                generatePattern.InitializeObjectList();
                generatePattern.AssignIndicesToObjects();
                // Genera y anima la lista de índices aleatorios
                generatePattern.GenerateRandomIndicesList();
                generatePattern.bomboAnimation.StartAnimationSequence();
                // Inicializa la lista de selección del jugador
                generatePattern.playerSelectedIndices = new List<int>();
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                CheckPlayerSelection();
            }
        }

        if (!authorizePlayPuzzle.thisObjectActive)
        {
            isPlaying = false;
        }

        if (isPlaying)
        {
            BomboPuzzlePlay();
        }

        if (generatePattern.correctPatternCount >= 5)
        {
            BomboPuzzleWin();
        }

        if (generatePattern.incorrectPatternCount >= 3)
        {
            BomboPuzzleGameOver();
        }
    }

    public void BomboPuzzlePlay()
    {

    }

    public void BomboPuzzleWin()
    {
        isPlaying = false;
        aciertos = 0;
        generatePattern.correctPatternCount = 0;
        generatePattern.incorrectPatternCount = 0;
    }

    public void BomboPuzzleGameOver()
    {
        isPlaying = false;
        aciertos = 0;
        generatePattern.correctPatternCount = 0;
        generatePattern.incorrectPatternCount = 0;
    }

    public void BomboPuzzleRestart()
    {

    }

    public void BomboPuzzleIncreaseAciertos()
    {
        aciertos++;
        Debug.Log("Subiste al nivel " + aciertos);
    }

    public void BomboPuzzleDecreaseAciertos()
    {
        aciertos--;
        Debug.Log("Bajaste al nivel " + aciertos);
    }

    // Método para comparar las dos listas y determinar el resultado
    public void CheckPlayerSelection()
    {
        // Verifica si las listas tienen el mismo tamaño antes de comparar
        if (generatePattern.playerSelectedIndices.Count == generatePattern.randomIndices.Count)
        {
            for (int i = 0; i < generatePattern.randomIndices.Count; i++)
            {
                // Si algún índice no coincide, es una derrota y se limpia la lista
                if (generatePattern.playerSelectedIndices[i] != generatePattern.randomIndices[i])
                {
                    Debug.Log("Derrota: Los índices no coinciden en orden.");
                    generatePattern.CountIncorrectPattern();
                    // Limpia la lista del jugador para un nuevo intento
                    generatePattern.playerSelectedIndices.Clear();
                    return;
                }
            }
            // Si todos los índices coinciden en orden, es una victoria
            Debug.Log("Victoria: Todos los índices coinciden en orden.");
            BomboPuzzleIncreaseAciertos();
            generatePattern.CountCorrectPattern();
            generatePattern.playerSelectedIndices.Clear();
            generatePattern.Shuffle();
            bomboAnimation.StartAnimationSequence();
        }
        else
        {
            // Si las listas no tienen el mismo tamaño, es una derrota y se limpia la lista
            Debug.Log("Derrota: Las listas no tienen el mismo tamaño.");
            generatePattern.CountIncorrectPattern();
            // Limpia la lista del jugador para un nuevo intento
            generatePattern.playerSelectedIndices.Clear();
        }
    }
}