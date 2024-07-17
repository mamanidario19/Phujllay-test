using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneChange(int scene){
        SceneManager.LoadScene(scene);
    }
    public void ExitAplication(){
        Application.Quit();
    }
}
