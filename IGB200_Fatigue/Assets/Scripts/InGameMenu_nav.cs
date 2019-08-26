using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InGameMenu_nav : MonoBehaviour
{
    
    public void Pause()
    {
        Debug.Log("Pause Button Clicked !");

        VideoPlayer video = GetComponent<VideoPlayer>();
        if (video.isPlaying)
        {
            Debug.Log("Intro Video Skipped!.");
            video.Stop();
        }
    }
}
