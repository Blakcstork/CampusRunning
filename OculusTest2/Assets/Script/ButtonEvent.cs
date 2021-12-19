using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{

    public GameObject pausePanel;


    public GameObject myVideo;
    public VideoPlayer videoClip;

    public void PauseGame()
    {
        if(pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            myVideo.SetActive(true);
            videoClip.playbackSpeed = 0f;

        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            myVideo.SetActive(true);
            videoClip.playbackSpeed = 1f;
        }
        
    }

    public void QuitGame() 
    {
        SceneManager.LoadScene("Start");
    }
    public void ResumeGame() 
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResetGame()
    {
        videoClip.time = 0f;
        pausePanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
