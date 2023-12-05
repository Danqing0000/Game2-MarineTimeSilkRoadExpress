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

    [System.Serializable]
    public class CRs //定义一个新的类 CRs是一个内容为字符串的列表
    {
        public List<string> CRContentList;
    }
    [System.Serializable]
    public class CRList //存储类型为CRs的列表
    {
        public List<CRs> CRLists;
    }
    public CRList listCRList = new CRList();

    public void Update()
    {
        //Debug.Log("this is task upload");
        //Debug.Log(allowtoAdd);
        if ((allowtoAdd == true) && (SceneManager.GetActiveScene().name == "Scene04Workspace"))
        {
            taskUpload();
            Debug.Log("Uploaded");
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
        //Debug.Log("1");
        int taskSerialRecord = 0;
        foreach (TMP_Text taskContent in taskeach)
        {
            taskContent.text = " ";
        }

        for (int i = 0; i < 6; i++)
        {
            if (listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[i] == "/") //  /说明没有任务
            {
                update.setTaskBool(i, false);
                update.finishState[i] = true;
            }
            else
            {
                taskeach[taskSerialRecord].text = listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[i];  //更新任务
                taskSerialRecord++;
                update.setTaskBool(i, true);
                update.getTotalTaskNum(taskSerialRecord); //不同文物的任务总数 最后一次更新的数值是可访问的最大序列号
            }
        }
        Debug.Log("Task updated already");
    }
}
