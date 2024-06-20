using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSceneController : MonoBehaviour
{
    public VideoClip startVideoClip;
    public VideoClip endVideoClip;

    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.clip = startVideoClip;

        videoPlayer.Play();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayStartVideo();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StopVideo();
        }
    }

    public void PlayStartVideo()
    {
        videoPlayer.clip = startVideoClip;

        videoPlayer.Play();
    }

    public void PlayEndVideo()
    {
        videoPlayer.clip = endVideoClip;

        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }
}
