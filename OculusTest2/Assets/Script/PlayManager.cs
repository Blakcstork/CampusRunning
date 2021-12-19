using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;


/*
 * public GameObject myVideo -> 360�� ���� �Ҵ�
 * public VideoPlayer videoClip -> 360�� ���� �Ҵ�
 * 
 * public void OnPlayvideo()
 * {
 *      myVideo.SetActive(true);
 *      videoClip.Play();
 * }
 * 
 * public void OnPauseVideo()
 * {
 *      myVideo.SetActive(false);
 *      videoClip.Pause();
 * }
 * public void OnResetVideo() {        
        videoClip.time = 0f;
        videoClip.playbackSpeed = 1f;
    }

  public void OnFastVideo(float speed) {
        videoClip.playbackSpeed = speed;
    }
 * ���� �÷��� �޼ҵ�
 * 
 * 
 * 
 * if (OVRCamerarig.Transform.Position (Vector3), y���� ��ȭ�ϸ�) // �Ӹ� ��鸮��
 *   OnPlayVideo()
 *  else
 *   OnPauseVideo()
 * 
 * Controller
 * 
 * 
 * Axis1D.PrimaryHandTrigger && Axis1D.SecondaryhandTrigger (���� �� ������)
 * 
 * 
 * OVRInput.Get() -> ���� ���¿��� ��� ȣ��
 * OVRInput.GetDown() -> ������ �� �� ���� ȣ��
 *
 * 
 * GetLocalControllerAcceleration ( OVRInput, controllerType ) : Vector3	
Gets the linear acceleration of the given Controller local to its tracking space. Only supported for Oculus LTouch and RTouch controllers. Non-tracked controllers will return Vector3.zero.
 * 
 */

public class PlayManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject completePanel;

    public GameObject myVideo;
    public VideoPlayer videoClip;

    public OVRCameraRig vrCamera;
    public OVRInput.Controller LeftCon;
    public OVRInput.Controller RightCon;


    public Text TestTxt;
    public Text TestTxt2;
    public Text completeText;
    public Text currentText;
    

    public void OnPlayVideo()
    {
        videoClip.playbackSpeed = 1f;
    }
    public void OnPauseVideo()
    {
        myVideo.SetActive(true);
        videoClip.playbackSpeed = 0f;

    }

    public void OnResetVideo()
    {
        videoClip.time = 0f;
    }

    public void OnFastVideo(float speed)
    {
        videoClip.playbackSpeed = speed;
    }

    // ���� �÷��� �� �Ͻ�����


    public void ChangeToMap()
    {
        SceneManager.LoadScene("MapSelect");
    }

    public void ChangeToMain()
    {
        SceneManager.LoadScene("Start");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("VideoPlay Started");
        completePanel.SetActive(false);
        OnPauseVideo();
        videoClip.Play();
        /*
        if(SceneChange.mapNumber == 0)
        {
            //�Ϲ� ���� ���
        }
        else if(SceneChange.mapNumber == 1)
        {
            // 1�� ���� ���
        }
        else if (SceneChange.mapNumber == 2)
        {
            // 2�� ���� ���
        }
        else if (SceneChange.mapNumber == 3)
        {
            // 3�� ���� ���
        } --> ���� ���ܼ� ���
        */

    }

    // Update is called once per frame
    void Update()
    {
        double currentRate = videoClip.time / videoClip.length;
        int currentState = (int)(currentRate * SceneChange.mapLength);
        Vector3 testVec = OVRInput.GetLocalControllerVelocity(LeftCon);
        Vector3 testVec2 = OVRInput.GetLocalControllerVelocity(RightCon);
        //TestTxt.text = "(" + testVec + ")" + "(" + testVec2 + ")" + "(" + testVec.magnitude + ")" + "(" + testVec2.magnitude + "), " + videoClip.length+ ", " + currentRate + ", " + currentState; // ��ġ �׽�Ʈ��(�����)
        //TestTxt2.text = "(" + OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) + "," + OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) + "), " + videoClip.playbackSpeed + "," ;
        currentText.text = "���ݱ��� �޸� �Ÿ� : " + currentState;
        
        
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) == true && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true) // ��ư ����ä��
        {
            if((testVec.magnitude > 0.1 && testVec.magnitude < 1.0) && (testVec2.magnitude > 0.1 && testVec2.magnitude < 1.0)) // �� ���� ���
            {
                OnPlayVideo(); 
            }
            else if(testVec.magnitude > 1.0 && testVec2.magnitude > 1.0)
            {
                OnFastVideo(10);
            }
            else
            {
                videoClip.playbackSpeed = 0f;
            }
        }
        else
        {
            videoClip.playbackSpeed = 0f;
        }


        if(currentRate >0.99)
        {
            videoClip.playbackSpeed = 0f;
            completePanel.SetActive(true);
            completeText.text = "����� �޸� �Ÿ���..." + currentState + "m";
        }
        else
        {
            completePanel.SetActive(false);
        }



    }
}