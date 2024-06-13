using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputs : MonoBehaviour
{
    public EnemyAimConstraintController enemyAimConstraintController;
    public CloudFollowCharacter cloudFollowCharacter;
    public WindForce windForce; // Referencia al script WindForce
    public int countPulseM = 0;
    public int countPulseC = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int result;
        // Comprueba si se presiona la tecla V
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Activa el viento
            windForce.ActivateWind();
        }

        // Comprueba si se suelta la tecla V
        if (Input.GetKeyUp(KeyCode.V))
        {
            // Desactiva el viento
            windForce.DeactivateWind();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            countPulseM++;
            result = countPulseM % 2;
            if (result == 1)
            {
                enemyAimConstraintController.IncreaseWeight();
            }
            if (result == 0)
            {
                enemyAimConstraintController.DecreaseWeight();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            countPulseC++;
            result = countPulseC % 2;
            if (result == 1)
            {
                cloudFollowCharacter.MakeSon();
            }
            if (result == 0)
            {
                cloudFollowCharacter.RemoveSon();
            }
        }
    }
}
