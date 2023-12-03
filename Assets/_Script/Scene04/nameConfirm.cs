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
    public TMP_Text notice;
    public TMP_Text idname;
    public TMP_Text idnum;

    public TMP_Text submit;
    public bool submitfinalState = false;
    public GameManager myManager;
    public void Start()
    {
        idname.text = "Name: " + myManager.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[0];
        idnum.text = "ID Number: " + myManager.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[1];

    }

    public void inputCheck()
    {
        // if ((serialInput.text == "ASD1234") && (nameInput.text == "11111"))
        // {
        //     Debug.Log("ok");
        //     notice.text = "correct";
        //     SceneManager.LoadScene("Scene00Start");
        // }
        // if ((serialInput.text != "ASD1234") || (nameInput.text != "11111"))
        // {
        //     notice.text = "input wrong";
        //     Debug.Log("wrong");
        // }
        // if ((serialInput.text == "") || (nameInput.text == "")) //it's not null!!!
        // {
        //     notice.text = "please input";
        //     Debug.Log("input incomplete");
        // }


        if ((nameInput.text == myManager.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[0]) && (serialInput.text == myManager.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[1]))
        {
            Debug.Log("ok");
            notice.text = "correct";
            submit.text = "Deliver";
            submitfinalState = true;
            //SceneManager.LoadScene("Scene00Start");
        }
        if ((nameInput.text != myManager.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[0]) || (serialInput.text != myManager.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[1]))
        {
            notice.text = "input wrong";
            Debug.Log("wrong");
        }
        if ((serialInput.text == "") || (nameInput.text == "")) //it's not null!!!
        {
            notice.text = "please input";
            Debug.Log("input incomplete");
        }
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
