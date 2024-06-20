using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InstantiateNotes : MonoBehaviour
{
    public AuthorizePlayPuzzle authorizePlayPuzzle; // Referencia a la clase AuthorizePlayPuzzle

    public PlayMusic playMusic;

    public GameObject yellowNote; // El objeto que quieres instanciar
    public Transform spawnYellowNote; // El objeto que marca la posición inicial
    public Transform endYellowNote; // El objeto que marca la posición final

    public GameObject blueNote; // El objeto que quieres instanciar
    public Transform spawnBlueNote; // El objeto que marca la posición inicial
    public Transform endBlueNote; // El objeto que marca la posición final

    public GameObject orangeNote; // El objeto que quieres instanciar
    public Transform spawnOrangeNote; // El objeto que marca la posición inicial
    public Transform endOrangeNote; // El objeto que marca la posición final

    public GameObject redNote; // El objeto que quieres instanciar
    public Transform spawnRedNote; // El objeto que marca la posición inicial
    public Transform endRedNote; // El objeto que marca la posición final

    public GameObject greenNote; // El objeto que quieres instanciar
    public Transform spawnGreenNote; // El objeto que marca la posición inicial
    public Transform endGreenNote; // El objeto que marca la posición final

    private float[] spawnTimesYellowNotes = {0.0f, 1.3f, 2.65f, 4.0f, 5.2f, 6.5f, 7.8f, 9.2f, 10.5f, 11.9f, 13.2f, 14.5f, 15.8f, 17.1f, 18.4f, 19.8f, 21.1f, 22.4f, 23.7f, 25.0f, 26.4f, 27.7f, 29.1f, 30.4f, 31.8f, 33.1f, 34.4f, 35.7f, 37.1f, 38.5f, 39.9f, 41.2f, 42.5f, 43.8f, 45.1f, 46.4f, 47.9f, 49.2f, 50.5f, 51.8f, 53.1f, 54.5f, 55.8f, 57.1f}; // Los momentos en los que quieres instanciar los objetos
    private float[] spawnTimesBlueNotes = { 0.0f, 1.31f, 2.66f, 4.03f, 5.32f, 6.67f, 7.98f, 9.34f, 10.66f, 12.01f, 13.30f, 14.58f, 15.93f, 17.25f, 18.60f, 19.97f, 21.28f, 22.59f, 23.90f, 25.32f, 26.53f, 27.89f, 29.31f, 30.70f, 31.98f, 33.28f, 34.61f, 35.94f, 37.29f, 38.63f, 40.0f, 41.31f, 42.67f, 43.97f, 45.29f, 46.63f, 48.01f, 49.31f, 50.71f, 51.98f, 53.32f, 54.60f, 55.98f };
    private float[] spawnTimesOrangeNotes = { 1.30f, 1.52f, 1.74f, 1.96f, 2.21f, 3.74f, 3.98f, 4.20f, 4.42f, 4.69f, 6.79f, 7.05f, 7.30f, 7.55f, 9.11f, 9.34f, 9.55f, 9.76f, 10.01f, 17.36f, 17.58f, 17.77f, 18.00f, 28.01f, 28.23f, 28.42f, 28.67f, 38.71f, 38.91f, 39.13f, 39.37f, 49.35f, 49.56f, 49.77f, 50.01f };
    private float[] spawnTimesRedNotes = { 2.69f, 2.90f, 3.14f, 7.99f, 8.23f, 8.46f, 18.65f, 18.89f, 19.14f, 29.34f, 29.56f, 29.79f, 39.99f, 40.22f, 40.46f, 50.67f, 50.89f, 51.13f };
    private float[] spawnTimesGreenNotes = { 0.67f, 2.0f, 3.38f, 4.64f, 5.99f, 7.33f, 8.62f, 10.0f, 11.19f, 12.49f, 14.58f, 15.25f, 16.63f, 17.93f, 19.26f, 20.60f, 21.96f, 23.26f, 24.61f, 25.93f, 27.26f, 28.57f, 29.94f, 31.28f, 32.59f, 33.94f, 35.30f, 36.59f, 37.99f, 39.33f, 40.66f, 41.94f, 43.27f, 44.57f, 45.93f, 47.30f, 48.61f, 49.98f, 51.28f, 52.62f, 53.95f, 55.19f, 56.52f };
    
    private List<float> spawnTimesNotes = new List<float>(); // Los momentos en los que quieres instanciar los objetos
    public float speed = 1.0f; // La velocidad a la que quieres que se mueva el objeto

    private int nextSpawnIndexYellow = 0; // El índice del próximo objeto a instanciar
    private int nextSpawnIndexBlue = 0; // El índice del próximo objeto a instanciar
    private int nextSpawnIndexOrange = 0; // El índice del próximo objeto a instanciar
    private int nextSpawnIndexRed = 0; // El índice del próximo objeto a instanciar
    private int nextSpawnIndexGreen = 0; // El índice del próximo objeto a instanciar

    private Vector3 directionYellowNote; // La dirección en la que quieres que se mueva el objeto
    private Vector3 directionBlueNote; // La dirección en la que quieres que se mueva el objeto
    private Vector3 directionOrangeNote; // La dirección en la que quieres que se mueva el objeto
    private Vector3 directionRedNote; // La dirección en la que quieres que se mueva el objeto
    private Vector3 directionGreenNote; // La dirección en la que quieres que se mueva el objeto

    public Quaternion rotation;

    private string filePath; // La ruta del archivo donde se guardarán los tiempos

    public bool isPlaying = false;
    public bool isSpawning = false;
    private float startTime; // El momento en que se presionó la tecla L

    // Start is called before the first frame update
    void Start()
    {
        // Calcula la dirección en la que se deben mover los objetos
        directionYellowNote = (endYellowNote.position - spawnYellowNote.position).normalized;
        directionBlueNote = (endBlueNote.position - spawnBlueNote.position).normalized;
        directionOrangeNote = (endOrangeNote.position - spawnOrangeNote.position).normalized;
        directionRedNote = (endRedNote.position - spawnRedNote.position).normalized;
        directionGreenNote = (endGreenNote.position - spawnGreenNote.position).normalized;

        // Define la ruta del archivo
        filePath = Path.Combine(Application.dataPath, "../spawnTimesOrangePrimerosNotes.txt");
    }

    // Update is called once per frame
    void Update()
    {
        if (authorizePlayPuzzle.thisObjectActive)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                startTime = Time.time; // Guarda el momento en que se presionó la tecla
                isPlaying = true;
                isSpawning = true;
                playMusic.PlayMusicGuitar();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isPlaying)
            {
                // Agrega el tiempo actual (desde que se presionó la tecla L) a la lista de tiempos de instanciación
                float spawnTime = Time.time - startTime;
                spawnTimesNotes.Add(spawnTime);

                // Escribe el tiempo en el archivo
                File.AppendAllText(filePath, spawnTime.ToString() + "\n");
            }
        }

        if (!authorizePlayPuzzle.thisObjectActive)
        {

        }

        if (isPlaying)
        {
            PlayGuitar();
        }

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    isPlaying = false;
        //}

        //// Si es el momento de instanciar el próximo objeto, hazlo
        //if (nextSpawnIndex < spawnTimes.Length && Time.time >= spawnTimes[nextSpawnIndex])
        //{
        //    // Instancia el objeto en la posición del objeto de inicio
        //    GameObject instance = Instantiate(myObject, spawnPositionObject.position, Quaternion.identity);

        //    // Añade un componente Rigidbody si no existe uno ya
        //    Rigidbody rb = instance.GetComponent<Rigidbody>();
        //    if (rb == null)
        //    {
        //        rb = instance.AddComponent<Rigidbody>();
        //    }

        //    // Desactiva la gravedad para este objeto
        //    rb.useGravity = false;

        //    // Mueve el objeto en la dirección y velocidad especificadas
        //    rb.velocity = direction * speed;

        //    // Prepara para instanciar el próximo objeto
        //    nextSpawnIndex++;
        //}
    }

    public void Restart()
    {
        startTime = Time.time; // Reinicia el tiempo de inicio del juego
        nextSpawnIndexYellow = 0; // Reinicia el índice de instanciación
        nextSpawnIndexBlue = 0; // Reinicia el índice de instanciación
        nextSpawnIndexOrange = 0; // Reinicia el índice de instanciación
        nextSpawnIndexRed = 0; // Reinicia el índice de instanciación
        nextSpawnIndexGreen = 0; // Reinicia el índice de instanciación
        isSpawning = true; // Reinicia la instanciación de objetos
        isPlaying = true;
    }

    private void PlayGuitar()
    {
        // Si es el momento de instanciar el próximo objeto, hazlo
        if (isSpawning && nextSpawnIndexYellow < spawnTimesYellowNotes.Length && Time.time - startTime >= spawnTimesYellowNotes[nextSpawnIndexYellow])
        {
            // Instancia el objeto en la posición del objeto de inicio
            GameObject instance = Instantiate(yellowNote, spawnYellowNote.position, rotation);

            // Añade un componente Collider si no existe uno ya y lo marca como Trigger
            Collider col = instance.GetComponent<Collider>();
            if (col == null)
            {
                col = instance.AddComponent<BoxCollider>(); // Puedes cambiar BoxCollider por el tipo de Collider que quieras
            }
            //col.isTrigger = true;

            // Asigna el Tag "Note" al objeto
            instance.tag = "Note";

            // Añade un componente Rigidbody si no existe uno ya
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = instance.AddComponent<Rigidbody>();
            }

            // Desactiva la gravedad para este objeto
            rb.useGravity = false;

            // Mueve el objeto en la dirección y velocidad especificadas
            rb.velocity = directionYellowNote * speed;

            // Prepara para instanciar el próximo objeto
            nextSpawnIndexYellow++;
        }

        // Si es el momento de instanciar el próximo objeto, hazlo
        if (isSpawning && nextSpawnIndexBlue < spawnTimesBlueNotes.Length && Time.time - startTime >= spawnTimesBlueNotes[nextSpawnIndexBlue])
        {
            // Instancia el objeto en la posición del objeto de inicio
            GameObject instance = Instantiate(blueNote, spawnBlueNote.position, rotation);

            // Añade un componente Collider si no existe uno ya y lo marca como Trigger
            Collider col = instance.GetComponent<Collider>();
            if (col == null)
            {
                col = instance.AddComponent<BoxCollider>(); // Puedes cambiar BoxCollider por el tipo de Collider que quieras
            }

            // Asigna el Tag "Note" al objeto
            instance.tag = "Note";

            // Añade un componente Rigidbody si no existe uno ya
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = instance.AddComponent<Rigidbody>();
            }

            // Desactiva la gravedad para este objeto
            rb.useGravity = false;

            // Mueve el objeto en la dirección y velocidad especificadas
            rb.velocity = directionBlueNote * speed;

            // Prepara para instanciar el próximo objeto
            nextSpawnIndexBlue++;
        }

        // Si es el momento de instanciar el próximo objeto, hazlo
        if (isSpawning && nextSpawnIndexOrange < spawnTimesOrangeNotes.Length && Time.time - startTime >= spawnTimesOrangeNotes[nextSpawnIndexOrange])
        {
            // Instancia el objeto en la posición del objeto de inicio
            GameObject instance = Instantiate(orangeNote, spawnOrangeNote.position, rotation);

            // Añade un componente Collider si no existe uno ya y lo marca como Trigger
            Collider col = instance.GetComponent<Collider>();
            if (col == null)
            {
                col = instance.AddComponent<BoxCollider>(); // Puedes cambiar BoxCollider por el tipo de Collider que quieras
            }
            col.isTrigger = true;

            // Asigna el Tag "Note" al objeto
            instance.tag = "Note";

            // Añade un componente Rigidbody si no existe uno ya
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = instance.AddComponent<Rigidbody>();
            }

            // Desactiva la gravedad para este objeto
            rb.useGravity = false;

            // Mueve el objeto en la dirección y velocidad especificadas
            rb.velocity = directionOrangeNote * speed;

            // Prepara para instanciar el próximo objeto
            nextSpawnIndexOrange++;
        }

        // Si es el momento de instanciar el próximo objeto, hazlo
        if (isSpawning && nextSpawnIndexRed < spawnTimesRedNotes.Length && Time.time - startTime >= spawnTimesRedNotes[nextSpawnIndexRed])
        {
            // Instancia el objeto en la posición del objeto de inicio
            GameObject instance = Instantiate(redNote, spawnRedNote.position, rotation);

            // Añade un componente Collider si no existe uno ya y lo marca como Trigger
            Collider col = instance.GetComponent<Collider>();
            if (col == null)
            {
                col = instance.AddComponent<BoxCollider>(); // Puedes cambiar BoxCollider por el tipo de Collider que quieras
            }
            col.isTrigger = true;

            // Asigna el Tag "Note" al objeto
            instance.tag = "Note";

            // Añade un componente Rigidbody si no existe uno ya
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = instance.AddComponent<Rigidbody>();
            }

            // Desactiva la gravedad para este objeto
            rb.useGravity = false;

            // Mueve el objeto en la dirección y velocidad especificadas
            rb.velocity = directionRedNote * speed;

            // Prepara para instanciar el próximo objeto
            nextSpawnIndexRed++;
        }

        // Si es el momento de instanciar el próximo objeto, hazlo
        if (isSpawning && nextSpawnIndexGreen < spawnTimesGreenNotes.Length && Time.time - startTime >= spawnTimesGreenNotes[nextSpawnIndexGreen])
        {
            // Instancia el objeto en la posición del objeto de inicio
            GameObject instance = Instantiate(greenNote, spawnGreenNote.position, rotation);

            // Añade un componente Collider si no existe uno ya y lo marca como Trigger
            Collider col = instance.GetComponent<Collider>();
            if (col == null)
            {
                col = instance.AddComponent<BoxCollider>(); // Puedes cambiar BoxCollider por el tipo de Collider que quieras
            }

            // Asigna el Tag "Note" al objeto
            instance.tag = "Note";

            // Añade un componente Rigidbody si no existe uno ya
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = instance.AddComponent<Rigidbody>();
            }

            // Desactiva la gravedad para este objeto
            rb.useGravity = false;

            // Mueve el objeto en la dirección y velocidad especificadas
            rb.velocity = directionGreenNote * speed;

            // Prepara para instanciar el próximo objeto
            nextSpawnIndexGreen++;
        }
    }
}