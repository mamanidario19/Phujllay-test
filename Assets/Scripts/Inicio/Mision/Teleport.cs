using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] private string nameScene;
    [SerializeField] private AnimationClip animacion;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);

            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(animacion.length);

        SceneManager.LoadScene(nameScene);
    }
}
