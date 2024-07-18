using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    public AudioClip interiorSound;
    public AudioClip exteriorSound;
    public Collider interiorCollider;

    private AudioSource audioSource;
    private bool isInside = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = exteriorSound;
        audioSource.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other == interiorCollider && !isInside)
            {
                audioSource.clip = interiorSound;
                audioSource.Play();
                isInside = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other == interiorCollider && isInside)
            {
                audioSource.clip = exteriorSound;
                audioSource.Play();
                isInside = false;
            }
        }
    }
}