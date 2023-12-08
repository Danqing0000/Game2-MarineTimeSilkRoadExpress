using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;


public class nameConfirm : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField serialInput;
    public TMP_InputField location1;
    public TMP_InputField location2;
    public TMP_InputField location3;
    public TMP_InputField notes;
    public TMP_Text notice;
    public TMP_Text idname;
    public TMP_Text idnum;
    public TMP_Text idcaller;

    public TMP_Text submit;
    public bool submitfinalState = false;
    public GameManager myManager;
    public TaskUpload myUpload;


    public bool testlocation = false;
    public bool testtime = false;
    public bool testnote = false;
    public void Start()
    {
        idname.text = myUpload.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[0]; //文物名称
        //idnum.text = "ID Number: " + myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[1]; //时间区域
        idcaller.text = myManager.listCRList.CRLists[GameManager.CRSerial].CRContentList[9]; //收件人信息

    }

    public void inputCheck()
    {
        testtime = false;
        testlocation = false;
        testnote = false;
        Debug.Log(myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[6] + myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[7] + myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[8]);
        if (serialInput.text == myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[1])
        {
            testtime = true;
            Debug.Log("time right");
        }
        if ((location1.text == myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[6]) && (location2.text == myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[7]) && (location3.text == myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[8]))
        {
            testlocation = true;
            Debug.Log("location right");

        }
        if (notes.text != "")
        {
            testnote = true;
            Debug.Log("notes right");
        }

        if ((testtime == true) && (testlocation == true) && (testnote == true))
        {
            submitfinalState = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("wrong");
            notice.text = "There is something wrong with the information, please check again.";
        }




        // if ((nameInput.text == myUpload.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[0]) && (serialInput.text == myUpload.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[1]))
        // {
        //     Debug.Log("ok");
        //     notice.text = "correct";
        //     submit.text = "Deliver";
        //     submitfinalState = true;
        //     //SceneManager.LoadScene("Scene00Start");
        // }
        // if ((nameInput.text != myUpload.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[0]) || (serialInput.text != myUpload.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[1]))
        // {
        //     notice.text = "input wrong";
        //     Debug.Log("wrong"   );
        // }
        // if ((serialInput.text == "") || (nameInput.text == "")) //it's not null!!!
        // {
        //     notice.text = "please input";
        //     Debug.Log("input incomplete");
        // }
    }

    public void deliverChangeScene()
    {
        if (submitfinalState == true)
        {
            SceneManager.LoadScene("Scene02Reception"); //add waitforseconds
            GameManager.sceneCheck = true; //改变场景的同时 调用Game Manager中的代码，判断选择的文物是否正确? 限制是否需要重新更新任务
            myManager.finalItemCheck();
            Debug.Log("final check called");
        }

    }
}
