using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfinadorPuzzleManager : MonoBehaviour
{
    public AuthorizePlayPuzzle authorizePlayPuzzle; // Referencia a la clase AuthorizePlayPuzzle
    public SB_Slidebar sb_Slidebar;
    public int numLevel = 1;
    public bool isPlaying = false;
    public GameObject cord1, cord2, cord3, cord4, cord5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (authorizePlayPuzzle.thisObjectActive)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                numLevel = 1;
                isPlaying = true;
                ActivateCord();
            }
        }

        if (!authorizePlayPuzzle.thisObjectActive)
        {
            isPlaying = false;
            AfinadorPuzzleRestart();
        }

        if (isPlaying)
        {
            AfinadorPuzzlePlay();
        }

        if (sb_Slidebar.correctPressCount >= 3)
        {
            //AfinadorPuzzleWin();
            AfinadorPuzzleIncreaseLevel();
        }

        if (sb_Slidebar.incorrectPressCount >= 3)
        {
            AfinadorPuzzleDecreaseLevel();
        }

        if (numLevel <= 0)
        {
            AfinadorPuzzleGameOver();
        }

        if (numLevel >= 6)
        {
            AfinadorPuzzleWin();
        }
    }

    public void StartPuzzleAfinador()
    {
        if (authorizePlayPuzzle.thisObjectActive)
        {        
            numLevel = 1;        
            isPlaying = true;       
            ActivateCord();
        }
    }

    public void AfinadorPuzzlePlay()
    {
        sb_Slidebar.PointMovement();
        sb_Slidebar.IsRangeStatus();
    }

    public void AfinadorPuzzleWin()
    {
        isPlaying = false;
        numLevel = 0;
        DisableCord();
    }

    public void AfinadorPuzzleGameOver()
    {
        isPlaying = false;
        numLevel = 0;
        DisableCord();
    }

    public void AfinadorPuzzleRestart()
    {
        numLevel = 0;
        DisableCord();
    }

    public void AfinadorPuzzleIncreaseLevel()
    {
        sb_Slidebar.correctPressCount = 0;
        sb_Slidebar.incorrectPressCount = 0;
        sb_Slidebar.ResetPointerVelocity();
        numLevel++;
        ActivateCord();
        Debug.Log("Subiste al nivel " + numLevel);
    }

    public void AfinadorPuzzleDecreaseLevel()
    {
        sb_Slidebar.incorrectPressCount = 0;
        sb_Slidebar.correctPressCount = 0;
        sb_Slidebar.ResetPointerVelocity();
        numLevel--;
        DisableCord();
        Debug.Log("Bajaste al nivel " + numLevel);
    }

    public void ActivateCord()
    {
        switch (numLevel)
        {
            case 1: 
                cord1.SetActive(true);
                break;
            case 2: 
                cord2.SetActive(true);
                break;
            case 3: 
                cord3.SetActive(true);
                break;
            case 4: 
                cord4.SetActive(true);
                break;
            case 5: 
                cord5.SetActive(true);
                break;            
        }
    }

    public void DisableCord()
    {
        switch (numLevel)
        {
            case 0:
                cord1.SetActive(false);
                cord2.SetActive(false);
                cord3.SetActive(false);
                cord4.SetActive(false);
                cord5.SetActive(false);
                break;
            case 1:
                cord2.SetActive(false);
                break;
            case 2:
                cord3.SetActive(false);
                break;
            case 3:
                cord4.SetActive(false);
                break;
            case 4:
                cord5.SetActive(false);
                break;
        }
    }
}