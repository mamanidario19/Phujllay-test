using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class Generador_Comensal : MonoBehaviour
{
    [SerializeField] private GameObject[] pRopaSuperior;
    [SerializeField] private GameObject[] pRopaInferior;
    [SerializeField] private GameObject[] pPelo;
    [SerializeField] private GameObject[] pBarba;
    [SerializeField] private GameObject[] pCuerpo;
    [SerializeField] private Material[] mRopaSuperior;
    [SerializeField] private Material[] mRopaInferior;
    [SerializeField] private Material[] mPelo;
    [SerializeField] private Material[] mPiel;

    private void Start()
    {
        ArmarParteDeCuerpo(pCuerpo, mPiel);

        ArmarParteDeCuerpo(pRopaSuperior, mRopaSuperior);

        ArmarParteDeCuerpo(pRopaInferior, mRopaInferior);

        if(PosicionAleatoria(2) == 1)
        {
            ArmarPeloYBarba(pPelo, pBarba, mPelo);
        }
        else
        {
            ArmarParteDeCuerpo(pPelo, mPelo);
        }
    }

    void ArmarParteDeCuerpo(GameObject[] aObjetos, Material[] aMateriales)
    {
        int posicion = PosicionAleatoria(aObjetos.Length);

        aObjetos[posicion].SetActive(true);

        AsignarMaterial(aObjetos[posicion], aMateriales);
    }

    void ArmarPeloYBarba(GameObject[] aPelos, GameObject[] aBarbas, Material[] aMateriales)
    {
        int posicion1 = PosicionAleatoria(aPelos.Length);

        int posicion2 = PosicionAleatoria(aBarbas.Length);

        aPelos[posicion1].SetActive(true);

        aBarbas[posicion2].SetActive(true);

        GameObject[] objetos = { aPelos[posicion1], aBarbas[posicion2] };

        AsignarMaterialAVariosObjetos(objetos, aMateriales);
    }

    private void AsignarMaterial(GameObject objeto, Material[] aMateriales)
    {
        Renderer renderer = objeto.GetComponent<Renderer>();

        renderer.material = ObtenerMaterialAleatorio(aMateriales);
    }

    private void AsignarMaterialAVariosObjetos(GameObject[] objeto, Material[] aMateriales)
    {
        Material material = ObtenerMaterialAleatorio(aMateriales);

        for (int i = 0; i < objeto.Length; i++)
        {
            Renderer renderer = objeto[i].GetComponent<Renderer>();

            renderer.material = material;
        }
    }

    private Material ObtenerMaterialAleatorio(Material[] aMateriales)
    {
        return aMateriales[PosicionAleatoria(aMateriales.Length)];
    }

    private int PosicionAleatoria(int valorMaximo)
    {
        return Random.Range(0, valorMaximo);
    }
}
