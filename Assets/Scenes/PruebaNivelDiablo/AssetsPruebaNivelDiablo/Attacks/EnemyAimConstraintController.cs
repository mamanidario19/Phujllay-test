using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyAimConstraintController : MonoBehaviour
{
    public MultiAimConstraint multiAimConstraint;
    public float duration = 1.0f; // Duración de la transición
    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que el componente está asignado
        if (multiAimConstraint == null)
        {
            multiAimConstraint = GetComponent<MultiAimConstraint>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseWeight()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeWeight(1.0f));
    }

    public void DecreaseWeight()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeWeight(0.0f));
    }

    private IEnumerator ChangeWeight(float target)
    {
        float start = multiAimConstraint.weight;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float normalizedTime = time / duration;
            multiAimConstraint.weight = Mathf.Lerp(start, target, normalizedTime);
            yield return null;
        }
        multiAimConstraint.weight = target;
    }
}
