using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private CharacterController player;
    [SerializeField] private Zorrito zorrito;  // Asigna la referencia al Zorrito desde el Inspector

    void Update()
    {
        Interaction();

    }

    private void Interaction() {

        // Verifica si se presiona la tecla 'E' para interactuar con el Zorrito
        if (Input.GetKeyDown(KeyCode.E))
        {
            zorrito.Interactuar();
        }

    }
}
