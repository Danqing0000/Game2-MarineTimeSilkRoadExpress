using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;


public class nameConfirm : MonoBehaviour
{
    public TMP_InputField serialInput;
    public TMP_InputField location1;
    public TMP_InputField location2;
    public TMP_InputField location3;
    public TMP_InputField notes;
    public TMP_Text notice;
    public TMP_Text idname;
    public TMP_Text idcaller;
    public bool submitfinalState = false;
    public GameManager myManager;
    public TaskUpload myUpload;


    public bool testlocation = false;
    public bool testtime = false;
    public bool testnote = false;
    public void Start()
    {
        idname.text = myUpload.listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[0]; //name of the item
        idcaller.text = myManager.listCRList.CRLists[GameManager.CRSerial].CRContentList[9]; //receiver information

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
        }
        if ((location1.text == myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[6]) && (location2.text == myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[7]) && (location3.text == myUpload.listCRList.CRLists[GameManager.CRSerial].CRContentList[8]))
        {
            testlocation = true;

        }
        if (notes.text != "")
        {
            testnote = true;
        }

        if ((testtime == true) && (testlocation == true) && (testnote == true))
        {
            submitfinalState = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            notice.text = "There is something wrong with the information, please check again.";
        }
    }

    public void deliverChangeScene()
    {
        if (submitfinalState == true)
        {
            StartCoroutine(WaitAndDoSomething());
            GameManager.sceneCheck = true; //if needs to update a new request
            myManager.finalItemCheck();
            Debug.Log("final check called");
        }
    }
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scene02Reception");
    }
}
