using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneChange(int scene){
        SceneManager.LoadScene(scene);
    }
public void StopMenuMusic() {
        MenuMusic.instance.StopMusic();
        MenuMusic.instance.DestroyAudio();
    }
    public void ExitAplication(){
        Application.Quit();
    }
}
