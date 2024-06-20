using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePattern : MonoBehaviour
{
    public BomboPuzzleManager bomboPuzzleManager; // Referencia a la clase BomboPuzzleManager
    public BomboAnimation bomboAnimation; // Referencia a la clase BomboAnimation
    public List<GameObject> puzzleObjects; // Lista para almacenar los objetos del puzzle
    public List<int> randomIndices; // Lista para almacenar los índices de forma aleatoria    
    public List<int> playerSelectedIndices;// Lista para almacenar los índices de los objetos seleccionados por el jugador
    public int correctPatternCount = 0;
    public int incorrectPatternCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bomboPuzzleManager.isPlaying)
        {
            // Detecta si el jugador hace clic con el mouse y selecciona un objeto
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject selectedObject = hit.transform.gameObject;
                    if (selectedObject.CompareTag("Bombo"))
                    {
                        Animator animator = selectedObject.GetComponent<Animator>();
                        int selectedIndex = selectedObject.GetComponent<BomboIndex>().index;
                        playerSelectedIndices.Add(selectedIndex);
                        animator.SetTrigger("PlayAnimation");
                        //Debug.Log("Objeto seleccionado con índice: " + selectedIndex);
                    }
                }
            }
        } 
    }

    public void CountCorrectPattern()
    {
        correctPatternCount++;
        Debug.Log(correctPatternCount);
    }

    public void CountIncorrectPattern()
    {
        incorrectPatternCount++;
        Debug.Log(incorrectPatternCount);
    }

    // Encuentra y almacena todos los objetos del puzzle en la lista
    public void InitializeObjectList()
    {
        puzzleObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bombo"));
    }

    // Asigna un índice único a cada objeto en la lista
    public void AssignIndicesToObjects()
    {
        for (int i = 0; i < puzzleObjects.Count; i++)
        {
            // Asigna un índice único a cada objeto
            puzzleObjects[i].GetComponent<BomboIndex>().index = i;
        }
    }

    // Crea una lista de índices y la mezcla aleatoriamente
    public void GenerateRandomIndicesList()
    {
        randomIndices = new List<int>();
        foreach (var obj in puzzleObjects)
        {
            randomIndices.Add(obj.GetComponent<BomboIndex>().index);
        }
        ShuffleList(randomIndices);
    }

    // Método para mezclar los elementos de una lista
    public void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    // Revuelve la lista de índices
    public void Shuffle()
    {
        ShuffleList(randomIndices);
    }
}