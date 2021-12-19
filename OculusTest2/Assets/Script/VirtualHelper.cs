using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class VirtualHelper : MonoBehaviour
{
    public GameObject MotorChibi;
    public GameObject TalkingPanel;
    public OVRCameraRig vrCamera;
    public Text TalkText;

    public GameObject myVideo;
    public VideoPlayer videoClip;


    public List<string> stringList = new List<string>();
    int currentState = 0;
    

    // Start is called before the first frame update

    public void talking()
    {
        if(MotorChibi.activeSelf== true) // 대화창 MotorChibi 있을때만 작동
        {
            stringList.RemoveAt(6); // 마지막 더미 지우고
            stringList.Add("지금까지 " + currentState + "m 나 달렸어, 대단해!");
            int ran = Random.Range(0, 7);
            TalkingPanel.SetActive(true);
            TalkText.text = stringList[ran];
        }
        else
        {
            TalkingPanel.SetActive(false);
        }

    }

    void Start()
    {
        MotorChibi.SetActive(true);

        stringList.Add("얼마 안남았어!");
        stringList.Add("조금 더 힘내!");
        stringList.Add("정말 아름답지 않아?");
        stringList.Add("경치를 즐겨봐...");
        stringList.Add("가끔씩은 주위를 둘러봐");
        stringList.Add("천천히 걷는게 뭐 어때서?");
        stringList.Add("더미");// 대사집 추가 // 마지막 거리 대사를 출력하기 위한 더미 대사

        TalkingPanel.SetActive(false);
        InvokeRepeating("talking", 10f, 10f);

    }


    public void ChibiTurnOnOff() // 옵션에서 도우미 끄고 켜는 기능
    {
        if(MotorChibi.activeSelf == false)
        {
            MotorChibi.SetActive(true);
        }
        else if(MotorChibi.activeSelf == true)
        {
            MotorChibi.SetActive(false);
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        double currentRate = videoClip.time / videoClip.length;
        currentState = (int)(currentRate * SceneChange.mapLength);
        

    }

    private void LateUpdate()
    {
        MotorChibi.transform.position = new Vector3(vrCamera.transform.position.x + 85, vrCamera.transform.position.y-10, vrCamera.transform.position.z + 210);
        
    }

    
}
