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

    public List<int> random;
    public Dialog myDialog;
    public static int finishedItem = 0; //完成邮寄的文物数量
    public static bool itemCheck; //当前邮寄的物品是否正确

    public GameObject scroingPage;
    public static bool autoAdd = true;


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
        // DontDestroyOnLoad(gameObject);
        //Debug.Log(this.gameObject.name);
        //RandomChar();
        //RandomCR();
    }

    public void Update()
    {
        // if ((SceneManager.GetActiveScene().name == "Scene04Workspace") && (sceneCheck == true))
        // {
        //     taskUpload();
        //     Debug.Log("task uploaded");
        // }

    }

    public void Start()
    {
        if ((SceneManager.GetActiveScene().name == "Scene04Workspace") && (sceneCheck == true))
        {
            taskUpload();
            Debug.Log("task uploaded");
        }

        // for (int n = 0; n < 5; n++)    //  Populate list
        // {
        //     random.Clear();
        //     random.Add(n);

        // }

        if ((SceneManager.GetActiveScene().name == "Scene02Reception") && (autoAdd == true))
        {
            for (int n = 0; n < 5; n++)    //  Populate list
            {
                //random.Clear();
                random.Add(n);
            }
            RandomCR();
            autoAdd = false;
            Debug.Log("random CR automatically");
        }
        Debug.Log("Autoadd " + autoAdd);
        Debug.Log("start function running now");

    }

    // public void RandomChar()
    // {
    //     RandomCharacter[CharSerial].SetActive(false); //hide original characters
    //     CharSerial = Random.Range(0, 5);
    //     Debug.Log("CharSerial=" + CharSerial);
    //     RandomCharacter[CharSerial].SetActive(true); //show new characters

    // }
    public void firstRandom()
    {
        if (autoAdd == true)
        {
            for (int n = 0; n < 5; n++)    //  Populate list
            {
                random.Clear();
                random.Add(n);
            }
            RandomCR();
            autoAdd = false;
        }
    }

    public void RandomCR()
    {
        // delete CR after using.
        // use List.length shrink the range of random serial number

        //CRSerial = Random.Range(0, 5);
        int index = Random.Range(0, random.Count - 1);    //  Pick random element from the list
        CRSerial = random[index];    //  the number that was randomly picked
        random.RemoveAt(index);   //  Remove chosen element


        Debug.Log("CRSerial=" + CRSerial);
        Debug.Log("index=" + index);
        //CRObjectList.RemoveAt(CRSerial);

        //Debug.Log(CRObjectList[CRSerial].name);
        //Debug.Log(CRContentList[CRSerial]);
        //Debug.Log(listCRList.CRLists[CRSerial].CRContentList[2]);
        if (SceneManager.GetActiveScene().name == "Scene04Workspace")
            CRObjectList[CRSerial].SetActive(false); //hide original characters

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

    public void finalItemCheck()  //用于进行最终判断，如果文物选择的不正确，将会收到负面反馈
    {
        Debug.Log("Right one " + CRSerial + "/ you chose " + CameraControl.ChoseSerial);
        if (finishedItem != 5)  //文物上限是5
        {
            if (CRSerial == CameraControl.ChoseSerial)
            {
                Debug.Log("Congratulation!");
                Debug.Log(sceneCheck);
                itemCheck = true;
                //myDialog.feedbackDialog(true);
                finishedItem = finishedItem + 1;
                Debug.Log("finished item " + finishedItem);
                //autoAdd = true;
                RandomCR();
                //myDialog.dialogUpload();
            }
            else
            {
                itemCheck = false;
                //myDialog.feedbackDialog(false);
                Debug.Log("you choose the wrong item！");
                Debug.Log(sceneCheck);
            }
        }
        else  //寄出了所有的文物
        {
            scroingPage.SetActive(true);
            autoAdd = false;
        }

    }
}
