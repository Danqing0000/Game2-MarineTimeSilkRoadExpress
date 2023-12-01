using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TaskUpdate update;
    public static GameManager myGameManager;
    //public List<GameObject> RandomCharacter;
    public List<GameObject> CRObjectList; //contain all the antiques
                                          //public List<List<string>> CRContentList;
                                          // public List<string> Cube; //contain all the requirements(reception scene), reference(warehouse scene), tasks(workspace scene)
                                          // public List<string> Sphere; //same as above, name of the lisr = name of the GameObject
                                          // public List<string> Cylinder;
                                          // public List<string> Capsule;

    public List<TMP_Text> taskeach;
    public static int CharSerial;
    public static int CRSerial;
    //public static int taskTotal;
    public static bool sceneCheck = true;


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

    // public void OnSceneLoaded(Scene scene, LoadSceneMode.Single)
    // {
    //     if (SceneManager.GetActiveScene().name == "Scene04Workspace")
    //     {
    //         taskUpload();
    //         Debug.Log("task uploaded");
    //     }

    // }

    void Awake()
    {
        if (myGameManager == null)
            myGameManager = this;
        // else if (myGameManager != this)
        //     Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
        //Debug.Log(this.gameObject.name);
        //RandomChar();
        //RandomCR();
    }

    // public void Update()
    // {
    //     if ((SceneManager.GetActiveScene().name == "Scene04Workspace") && (sceneCheck == true))
    //     {
    //         taskUpload();
    //         Debug.Log("task uploaded");
    //     }

    // }

    public void Start()
    {
        if ((SceneManager.GetActiveScene().name == "Scene04Workspace") && (sceneCheck == true))
        {
            taskUpload();
            Debug.Log("task uploaded");
        }

    }

    // public void RandomChar()
    // {
    //     RandomCharacter[CharSerial].SetActive(false); //hide original characters
    //     CharSerial = Random.Range(0, 5);
    //     Debug.Log("CharSerial=" + CharSerial);
    //     RandomCharacter[CharSerial].SetActive(true); //show new characters

    // }

    public void RandomCR()
    {
        // delete CR after using.
        // use List.length shrink the range of random serial number

        CRSerial = Random.Range(0, 5);
        Debug.Log("CRSerial=" + CRSerial);
        //CRObjectList.RemoveAt(CRSerial);

        //Debug.Log(CRObjectList[CRSerial].name);
        //Debug.Log(CRContentList[CRSerial]);
        //Debug.Log(listCRList.CRLists[CRSerial].CRContentList[2]);
        if (SceneManager.GetActiveScene().name == "Scene04Workspace")
            CRObjectList[CRSerial].SetActive(false); //hide original characters

    }


    public void taskUpload()
    {
        CRObjectList[CRSerial].SetActive(true);
        //Debug.Log("1");
        int taskSerialRecord = 0;
        foreach (TMP_Text taskContent in taskeach)
        {
            taskContent.text = " ";
        }

        for (int i = 0; i < 6; i++)
        {
            if (listCRList.CRLists[CRSerial].CRContentList[i] == "/") //  /说明没有任务
            {
                update.setTaskBool(i, false);
                update.finishState[i] = true;
            }
            else
            {
                taskeach[taskSerialRecord].text = listCRList.CRLists[CRSerial].CRContentList[i];  //更新任务
                taskSerialRecord++;
                update.setTaskBool(i, true);
                // if (i > 1)
                // {
                //     update.getTaskBool(i, true); // first two items are not tasks. Name+ serial number. keep false
                // }
                // else
                //     update.getTaskBool(i, false);

                update.getTotalTaskNum(taskSerialRecord); //不同文物的任务总数 最后一次更新的数值是可访问的最大序列号
            }
        }
        sceneCheck = false;
    }
}
