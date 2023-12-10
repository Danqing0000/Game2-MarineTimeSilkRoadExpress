using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskUpload : MonoBehaviour
{
    public List<GameObject> CRObjectList;
    public List<TMP_Text> taskeach;
    public TaskUpdate update;
    public static bool allowtoAdd = true;
    public TaskUpload myUpload;
    public HintChange myHint;

    [System.Serializable]
    public class CRs
    {
        public List<string> CRContentList;
    }
    [System.Serializable]
    public class CRList
    {
        public List<CRs> CRLists;
    }
    public CRList listCRList = new CRList();

    public void Update()
    {
        if ((allowtoAdd == true) && (SceneManager.GetActiveScene().name == "Scene04Workspace"))
        {
            taskUpload();
            allowtoAdd = false;
        }

    }

    public void taskUpload()
    {
        
        foreach (GameObject item in CRObjectList)
        {
            item.SetActive(false);
        }
        CRObjectList[CameraControl.ChoseSerial].SetActive(true);
        int taskSerialRecord = 0;
        foreach (TMP_Text taskContent in taskeach)
        {
            taskContent.text = " ";
        }

        for (int i = 0; i < 6; i++)
        {
            if (listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[i] == "/") //  /means no task
            {
                update.setTaskBool(i, false);
                update.finishState[i] = true;
            }
            else
            {
                taskeach[taskSerialRecord].text = listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[i];  //update task
                taskSerialRecord++;
                update.setTaskBool(i, true);
                update.getTotalTaskNum(taskSerialRecord); //total number of tasks
            }
        }
        myHint.hintchange();
    }
}
