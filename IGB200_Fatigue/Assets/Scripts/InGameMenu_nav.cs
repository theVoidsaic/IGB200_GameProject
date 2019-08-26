using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

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
            video.enabled = false;
        }
    }

    public void Reset()
    {
        Debug.Log("Reseting Game. Loading default Game Scene (2)...");
        SceneManager.LoadScene(2);   
    }
}
