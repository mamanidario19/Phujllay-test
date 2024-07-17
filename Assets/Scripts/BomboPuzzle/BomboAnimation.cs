using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomboAnimation : MonoBehaviour
{
    public BomboPuzzleManager bomboPuzzleManager; // Referencia a la clase BomboPuzzleManager
    public GeneratePattern generatePattern; // Referencia a la clase GeneratePattern
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // M�todo para iniciar la secuencia de animaciones
    public void StartAnimationSequence()
    {
        if (bomboPuzzleManager.isPlaying)
        {
            StartCoroutine(PlayAnimationsInOrder());
        }
    }

    private IEnumerator PlayAnimationsInOrder()
    {
        if (generatePattern.correctPatternCount != 5)
        {
            foreach (int index in generatePattern.randomIndices)
            {
                GameObject objectToAnimate = generatePattern.puzzleObjects[index];
                Animator animator = objectToAnimate.GetComponent<Animator>();

                // Aseg�rate de tener un trigger en tu Animator llamado "PlayAnimation"
                animator.SetTrigger("PlayAnimation");

                // Espera a que la animaci�n termine antes de continuar con el siguiente objeto
                // Aseg�rate de ajustar la duraci�n seg�n la longitud de tu animaci�n
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
