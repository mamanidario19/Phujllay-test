using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorritoSoundManager : MonoBehaviour
{
    public AudioSource[] audioSources;
    public AudioClip[] sniffSounds, barkSounds, snarlsSounds, gaspsSounds, interactionSounds;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayRandomSound(sniffSounds, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayRandomSound(barkSounds, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayRandomSound(snarlsSounds, 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayRandomSound(gaspsSounds, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayRandomSound(interactionSounds, 4);
        }
    }

    public void PlayRandomSound(AudioClip[] clips, int sourceIndex)
    {
        if (sourceIndex < audioSources.Length && clips.Length > 0)
        {
            AudioSource audioSource = audioSources[sourceIndex];
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Indice de AudioSource o array de clips fuera de rango.");
        }
    }
}
