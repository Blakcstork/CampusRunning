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
        if(MotorChibi.activeSelf== true) // ��ȭâ MotorChibi �������� �۵�
        {
            stringList.RemoveAt(6); // ������ ���� �����
            stringList.Add("���ݱ��� " + currentState + "m �� �޷Ⱦ�, �����!");
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

        stringList.Add("�� �ȳ��Ҿ�!");
        stringList.Add("���� �� ����!");
        stringList.Add("���� �Ƹ����� �ʾ�?");
        stringList.Add("��ġ�� ��ܺ�...");
        stringList.Add("�������� ������ �ѷ���");
        stringList.Add("õõ�� �ȴ°� �� ���?");
        stringList.Add("����");// ����� �߰� // ������ �Ÿ� ��縦 ����ϱ� ���� ���� ���

        TalkingPanel.SetActive(false);
        InvokeRepeating("talking", 10f, 10f);

    }


    public void ChibiTurnOnOff() // �ɼǿ��� ����� ���� �Ѵ� ���
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
