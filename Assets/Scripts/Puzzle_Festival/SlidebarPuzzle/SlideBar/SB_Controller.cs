using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_Controller : MonoBehaviour
{
    [SerializeField] private int numCord;
    [SerializeField] private int count = 0;
    [SerializeField] private SB_Slidebar slidebar;
    //GET - SET
    public int Cord { get { return numCord; } }
    public int Count { get { return count; } set { count = value; } }
    private void Update() {
        Counting();
    }
    private void Counting() {
        if (count == numCord) {
            Win();
        }
    }
    private void Win() {
        slidebar.Vel = 0;
        Debug.Log("WIIIIIIIN");
    }
}
