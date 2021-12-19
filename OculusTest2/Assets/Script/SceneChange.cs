using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public static float mapLength = 1000;

    void Start()
    {
        
    }
    public void ChangeToMain()
    {
        SceneManager.LoadScene("Start");
    }

    public void ChangeToMap()
    {
        SceneManager.LoadScene("MapSelect");
    }

    public void ChangeToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SelectRoute1()
    {
        SceneManager.LoadScene("PlayScene");
        mapLength = 1200;
    }

    public void SelectRoute2()
    {
        SceneManager.LoadScene("PlayScene2");
        mapLength = 950;
    }

    public void SelectRoute3()
    {
        SceneManager.LoadScene("PlayScene3");
        mapLength = 992;
    }
}
