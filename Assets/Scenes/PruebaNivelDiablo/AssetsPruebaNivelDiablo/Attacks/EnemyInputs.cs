using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputs : MonoBehaviour
{
    public List<ParticleSpeedIncrease> particleSpeedIncreaseObjects = new List<ParticleSpeedIncrease>();
    public AuthorizePlayNivelDiablo authorizePlayNivelDiablo;
    public EnemyAimConstraintController enemyAimConstraintController;
    public CloudFollowCharacter cloudFollowCharacter;
    public CameraShake cameraShake;
    public RockAttack rockAttack;
    public WindForce windForce; // Referencia al script WindForce
    public int countPulseM = 0;
    public int countPulseC = 0;

    public float minAttackInterval = 5f;
    public float maxAttackInterval = 7f;
    public float timeSinceLastAttack = 0f;
    public float nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        SetNextAttackTime();
    }

    // Update is called once per frame
    void Update()
    {
        int result;

        if (Input.GetKeyDown(KeyCode.H))
        {
            rockAttack.SomeOtherFunction();
            cameraShake.ShakeCamera();
        }

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

        timeSinceLastAttack += Time.deltaTime;

        if (timeSinceLastAttack >= nextAttackTime)
        {
            ChooseRandomAttack();
        }
    }

    public void ChooseRandomAttack()
    {
        int randomAttack = Random.Range(1, 3);

        switch (randomAttack)
        {
            case 1:
                ActivateAttack1();
                break;
            case 2:
                ActivateAttack2();
                break;         
        }

        SetNextAttackTime();
    }

    public void SetNextAttackTime()
    {
        nextAttackTime = Random.Range(minAttackInterval, maxAttackInterval);
        timeSinceLastAttack = 0f;
    }



    public void ActivateAttack1()
    {
        rockAttack.SomeOtherFunction();
        cameraShake.ShakeCamera();
    }

    public void ActivateAttack2()
    {
        foreach (var particleSpeedIncrease in particleSpeedIncreaseObjects)
        {
            particleSpeedIncrease.IncreaseSpeeds();
        }
        windForce.ActivateWind();
        Invoke("DesactiveAttack2", 2f);
    }

    public void DesactiveAttack2()
    {
        foreach (var particlesSpeedIncrease in particleSpeedIncreaseObjects)
        {
            particlesSpeedIncrease.DecreaseSpeeds();
        }
        windForce.DeactivateWind();
    }

    public void ActivateAttack3()
    {

    }

    public void ActivateAttack4()
    {

    }
}
