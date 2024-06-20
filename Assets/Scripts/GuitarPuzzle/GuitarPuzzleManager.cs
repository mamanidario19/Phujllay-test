using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPuzzleManager : MonoBehaviour
{
    public AuthorizePlayPuzzle authorizePlayPuzzle; // Referencia a la clase AuthorizePlayPuzzle
    public PlayMusic playMusic;
    public InstantiateNotes instantiateNotes;
    public int incorrectPressCount = 0; // Contador de presiones incorrectas
    public bool isWin = false;
    public bool isGameOver = false;
    public bool isPlayingPuzzle = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (authorizePlayPuzzle.thisObjectActive)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(GuitarPuzzleRestartt());
            }
        }

        if (!authorizePlayPuzzle.thisObjectActive)
        {
            incorrectPressCount = 0;
            playMusic.song1.Stop(); // Detiene la primera canción
            playMusic.song2.Stop(); // Detiene la segunda canción
            instantiateNotes.isSpawning = false; // Detiene la instanciación de objetos
            instantiateNotes.isPlaying = false;
        }

        if (!playMusic.song1.isPlaying && !playMusic.song2.isPlaying) // Comprueba si las canciones han terminado
        {
            GuitarPuzzleWin(); // Invoca el método GuitarPuzzleWin
        }

        if (incorrectPressCount >= 10) // Comprueba si el contador de presiones incorrectas es igual o mayor a 10
        {
            GuitarPuzzleGameOver(); // Invoca el método GameOver
        }
    }

    public void GuitarPuzzleGameOver()
    {
        isWin = false;
        isPlayingPuzzle = false;
        isGameOver = true;
        incorrectPressCount = 0;
        playMusic.song1.Stop(); // Detiene la primera canción
        playMusic.song2.Stop(); // Detiene la segunda canción
        instantiateNotes.isSpawning = false; // Detiene la instanciación de objetos
        instantiateNotes.isPlaying = false;
        Debug.Log("Has perdido el juego"); // Muestra un mensaje de que has perdido el juego
    }

    public void GuitarPuzzleWin()
    {
        isGameOver = false;
        isPlayingPuzzle = false;
        isWin = true;
        //Debug.Log("¡Has ganado el juego!"); // Muestra un mensaje de que has ganado el juego
    }

    public void RestartMusic()
    {
        playMusic.song1.Stop(); // Detiene la primera canción
        playMusic.song2.Stop(); // Detiene la segunda canción
        playMusic.song1.Play(); // Reinicia la primera canción        
        playMusic.song2.Play(); // Reinicia la segunda canción        
    }

    IEnumerator GuitarPuzzleRestartt()
    {
        instantiateNotes.Restart();
        yield return new WaitForSeconds(0.3f);
        RestartMusic();
    }
}