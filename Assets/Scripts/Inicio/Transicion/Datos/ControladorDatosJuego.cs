using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControladorDatosJuego : MonoBehaviour
{
    [SerializeField] private GameObject jugador;
    [SerializeField] private string archivoDeGuardado;
    [SerializeField] private DatosJuego datosJuego = new DatosJuego();

    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";

        jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador == null)
        {
            Debug.LogError("Jugador no encontrado. Asegúrate de que el objeto tiene la etiqueta 'Player'.");
        }
    }

    private void Start()
    {
        CargarDatos();
    }

    public void CargarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);

            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);

            Debug.Log("Posición cargada: " + datosJuego.PosicionAparicion);

            jugador.transform.position = datosJuego.PosicionAparicion;
        }
        else
        {
            Debug.Log("Archivo de guardado no existe.");
        }
    }

    public void GuardarDatos(Transform spawn)
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            PosicionAparicion = spawn.position,
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJSON);

        Debug.Log("Archivo guardado. Posición guardada: " + nuevosDatos.PosicionAparicion);
    }
}
