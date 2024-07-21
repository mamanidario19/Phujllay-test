using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class PlayButtonHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private string sceneToLoad;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = clickSound;

        Button button = GetComponent<Button>();

        button.onClick.AddListener(OnPlayButtonClicked);
    }

    void OnPlayButtonClicked()
    {
        StartCoroutine(PlaySoundAndChangeScene());
    }

    IEnumerator PlaySoundAndChangeScene()
    {
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length - 1);

        animator.gameObject.SetActive(true);

        animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(sceneToLoad);
    }
}