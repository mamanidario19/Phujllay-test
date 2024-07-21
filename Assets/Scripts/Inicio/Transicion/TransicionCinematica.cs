using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TransicionCinematica : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string nameScene;
    [SerializeField] private Animator animatorInicial;
    [SerializeField] private Animator animatorFinal;

    private void Start()
    {
        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena()
    {
        animatorInicial.SetTrigger("Iniciar");

        Debug.Log(videoPlayer.clip.length - 1);

        yield return new WaitForSeconds((float)(videoPlayer.clip.length - 1));

        animatorFinal.gameObject.SetActive(true);

        animatorFinal.SetTrigger("Iniciar");

        yield return new WaitForSeconds(animatorFinal.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(nameScene);
    }
}
