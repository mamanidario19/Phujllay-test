using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private MenuMusic music;
    [SerializeField] private int scene;
    private Image logoTeam;
    private bool loadFinish;
    private bool endLogo;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
        logoTeam = GetComponent<Image>();
        loadFinish = false;
        endLogo = false;

        logoTeam.color = new Color(logoTeam.color.r, logoTeam.color.g, logoTeam.color.b, 0f);
    }
    private void Start() {
        loadFinish = true;
    }
    public void Update() {
        if (loadFinish && endLogo)
        {
            SceneManager.LoadScene(scene);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void EndAnimationLogo ( ) {
        endLogo = true;
    }
    public void AudioPlay() {
        music.PlayMusic();
    }
}
