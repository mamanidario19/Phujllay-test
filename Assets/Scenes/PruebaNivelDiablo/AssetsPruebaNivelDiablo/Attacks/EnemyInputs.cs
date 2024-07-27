using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputs : MonoBehaviour
{
    public FlashEffect flashEffect;
    public ParticleSpeedIncrease[] particleSpeedIncreaseInstances;
    public EnemyAimConstraintController enemyAimConstraintController;
    public CloudFollowCharacter cloudFollowCharacter;
    public CameraShake cameraShake;
    public RockAttack rockAttack;
    public WindForce windForce; // Referencia al script WindForce
    public int countPulseM = 0;
    public int countPulseC = 0;
    [SerializeField] private AuthorizePlayNivelDiablo authorizePlayNivelDiablo;

    public float minAttackInterval = 5f;
    public float maxAttackInterval = 7f;
    public float timeSinceLastAttack = 0f;
    public float nextAttackTime;

    void Start()
    {
        enemyAimConstraintController.IncreaseWeight();

        SetNextAttackTime();

        particleSpeedIncreaseInstances = this.gameObject.GetComponentsInChildren<ParticleSpeedIncrease>();
    }

    void Update()
    {
        if (authorizePlayNivelDiablo.thisObjectActive)
        {
            int result;

            if (Input.GetKeyDown(KeyCode.F))
            {
                flashEffect.CaptureScreen();
            }

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
    }

    public void ChooseRandomAttack()
    {
        int randomAttack = Random.Range(1, 4);

        switch (randomAttack)
        {
            case 1:
                ActivateAttack1();
                break;
            case 2:
                ActivateAttack2();
                break;
            case 3:
                ActivateAttack3();
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
        foreach (var particleSpeedIncrease in particleSpeedIncreaseInstances)
        {
            particleSpeedIncrease.IncreaseSpeeds();
        }
        windForce.ActivateWind();
        Invoke("DesactiveAttack2", 2f);
    }

    public void DesactiveAttack2()
    {
        foreach (var particlesSpeedIncrease in particleSpeedIncreaseInstances)
        {
            particlesSpeedIncrease.DecreaseSpeeds();
        }
        windForce.DeactivateWind();
    }


    public void ActivateAttack3()
    {
        flashEffect.CaptureScreen();
    }

    public void ActivateAttack4()
    {

    }
}
