using UnityEngine;

public class CollectibleRotationAndLevitation : MonoBehaviour
{
    //[SerializeField] private float rotationSpeed = 20f; // Velocidad de rotacion
    [SerializeField] private float levitationAmplitude = 0.5f; // Amplitud de la levitacion
    [SerializeField] private float levitationFrequency = 1f; // Frecuencia de la levitacion

    private Vector3 startPos; // Posicion inicial del objeto

    void Start()
    {
        // Guardar la posicion inicial del objeto
        startPos = transform.position;
    }

    void Update()
    {
        // Rotacion del objeto
        //transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);

        // Levitación del objeto
        float newY = startPos.y + Mathf.Sin(Time.time * levitationFrequency) * levitationAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}