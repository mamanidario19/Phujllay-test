using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class PlayButtonHandler : MonoBehaviour
{
    public AudioClip clickSound;
    public string sceneToLoad;
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
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(sceneToLoad);
    }
}