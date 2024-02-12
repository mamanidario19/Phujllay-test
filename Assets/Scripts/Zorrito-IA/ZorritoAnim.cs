using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorritoAnim : MonoBehaviour
{
    public Animator anim;
    public void Idle(){
        anim.SetBool("Caminando",false);
    }
    public void Walk(){
        anim.SetBool("Caminando",true);
    }
    public void Search(){
        anim.SetBool("Buscando",true);
    }
    public void IsNotSearch(){
        anim.SetBool("Buscando",false);   
    }

    
}
