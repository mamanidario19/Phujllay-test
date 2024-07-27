using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 1.5f; // Duración del temblor
    public float shakeMagnitude = 4f; // Magnitud del temblor
    private Quaternion originalRotation;

    public void ShakeCamera()
    {
        originalRotation = transform.rotation;
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // Calcula la magnitud del temblor para este frame
            float remainingTime = shakeDuration - elapsed;
            float currentMagnitude = shakeMagnitude * Mathf.Pow(remainingTime / shakeDuration, 2);

            float z = Random.Range(-1f, 1f) * currentMagnitude;
            //float y = Random.Range(5.65f, 5.70f) * shakeMagnitude;

            transform.localRotation = originalRotation * Quaternion.Euler(originalRotation.x, originalRotation.y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localRotation = originalRotation;
    }
}
