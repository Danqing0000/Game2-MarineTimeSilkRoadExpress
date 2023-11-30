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

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Scene04Workspace")
        {
            taskUpload();
        }

    }

    void Awake()
    {
        if (myGameManager == null)
            myGameManager = this;
        else if (myGameManager != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //Debug.Log(this.gameObject.name);
        //RandomChar();
        //RandomCR();
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
        CRObjectList[CRSerial].SetActive(false); //hide original characters
        CRSerial = Random.Range(0, 5);
        Debug.Log("CRSerial=" + CRSerial);
        //CRObjectList.RemoveAt(CRSerial);

        Debug.Log(CRObjectList[CRSerial].name);
        //Debug.Log(CRContentList[CRSerial]);
        //Debug.Log(listCRList.CRLists[CRSerial].CRContentList[2]);

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

        for (int i = 0; i < 5; i++)
        {
            if (listCRList.CRLists[CRSerial].CRContentList[i] == "/") //  /说明没有任务
            {
                update.getTaskBool(i, false);
            }
            else
            {
                taskeach[taskSerialRecord].text = listCRList.CRLists[CRSerial].CRContentList[i];  //更新任务
                taskSerialRecord++;
                if (i > 0)
                {
                    update.getTaskBool(i, true); // 第一项并不是任务 而是标题 i>0时才是真正的任务 但是第一项一直保持false
                }
                else
                    update.getTaskBool(i, false);

                update.getTotalTaskNum(taskSerialRecord); //不同文物的任务总数 最后一次更新的数值是可访问的最大序列号
            }


        }
    }
}
