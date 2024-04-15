using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anataPuzle : MonoBehaviour
{
    public GameObject puntaObjeto;
    public GameObject cuerpoObjeto;
    public GameObject baseObjeto;

    private bool ordenCorrecto = false;
    private bool orientacionCorrecta = false;

    private void Update()
    {
        if (ordenCorrecto && orientacionCorrecta)
        {
            // Puzzle resuelto
            Debug.Log("Has armado correctamente la Anata!, ve a avisarle al músico!");
        }
    }

    public void VerificarOrdenYRotacion()
    {
        if (puntaObjeto.transform.position.y > cuerpoObjeto.transform.position.y &&
            cuerpoObjeto.transform.position.y > baseObjeto.transform.position.y)
        {
            ordenCorrecto = true;
        }
        else
        {
            ordenCorrecto = false;
        }

        if (puntaObjeto.transform.forward == Vector3.forward &&
            cuerpoObjeto.transform.forward == Vector3.forward &&
            baseObjeto.transform.forward == Vector3.forward)
        {
            orientacionCorrecta = true;
        }
        else
        {
            orientacionCorrecta = false;
        }
    }
}