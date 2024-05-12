using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombo_Puzzle : MonoBehaviour
{
    [SerializeField] private GameObject piece;
    [SerializeField] private List<GameObject> bomboSecuence;
    private List<GameObject> bomboList = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        if (bomboSecuence.Contains(other.gameObject))
        {
            if (!bomboList.Contains(other.gameObject)){
                bomboList.Add(other.gameObject);
            }
            for (int i = 0; i < bomboList.Count; i++)
            {
                if (bomboSecuence[i] == bomboList[i])
                {
                    if (bomboList.Count == bomboSecuence.Count)
                    {
                        piece.SetActive(true);
                        Debug.Log("WIIIIN");
                        //Win();
                    }                    
                } else {
                    bomboList.Clear();
                }
            }
        }
    }
    /*private void Win(){
        Debug.Log("WWIIIIIN");
    }*/
}
