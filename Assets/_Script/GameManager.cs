using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    public TaskUpdate update;
    public static GameManager myGameManager;
    public List<GameObject> CRObjectList; //contain all the antiques
    public List<TMP_Text> taskeach;
    public static int CharSerial;
    public static int CRSerial;
    //public static int taskTotal;
    public static bool sceneCheck = true;

    public List<int> random;
    //public Dialog myDialog;
    public static int finishedItem = 0; //完成邮寄的文物数量
    public static bool itemCheck; //当前邮寄的物品是否正确

    GameObject scroingPage;
    public static bool autoAdd = true;
    public static bool compare = false;
    public static bool scoring = false;
    public static int index = 0;
    public RandomSerialNum myRandom; //?
    public static bool AddList = true;


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

        DontDestroyOnLoad(gameObject);
        //RandomCR();
    }

    public void Update()
    {

    }

    public void Start()
    {
        if ((SceneManager.GetActiveScene().name == "Scene04Workspace") && (AddList == true))
        {
            taskeach.Clear();
            CRObjectList.Clear();
            taskeach.Add(GameObject.Find("Task Title").GetComponent<TMP_Text>());
            taskeach.Add(GameObject.Find("TaskID").GetComponent<TMP_Text>());
            taskeach.Add(GameObject.Find("Task1").GetComponent<TMP_Text>());
            taskeach.Add(GameObject.Find("Task2").GetComponent<TMP_Text>());
            taskeach.Add(GameObject.Find("Task3").GetComponent<TMP_Text>());
            taskeach.Add(GameObject.Find("Task4").GetComponent<TMP_Text>());

            CRObjectList.Add(GameObject.Find("Bag"));
            CRObjectList.Add(GameObject.Find("Coin"));
            CRObjectList.Add(GameObject.Find("Compass"));
            CRObjectList.Add(GameObject.Find("Dish"));
            CRObjectList.Add(GameObject.Find("Fan"));

            Debug.Log("find");
            AddList = false;
        }
        if ((SceneManager.GetActiveScene().name == "Scene04Workspace") && (sceneCheck == true))
        {
            taskUpload();
            Debug.Log("task uploaded");
        }

        Debug.Log("Autoadd " + autoAdd);
        Debug.Log("start function running now");

        // if ((scoring == true) && (SceneManager.GetActiveScene().name == "Scene02Reception"))
        //     scroingPage = GameObject.Find("ScoringPage");
        //     scroingPage.SetActive(true);

        //myRandom.currentSerial();
        Debug.Log(CRSerial);
    }

    public void RandomCR() //生成一个不重复的随机数序列
    {
        bool allowtoAdd = false;
        int n = 0;
        // for (int n = 0; n < 5; n++)    //  Populate list
        // {
        while (n < 5)
        {
            //Debug.Log("n is " + n);
            allowtoAdd = true;
            int t = Random.Range(0, 5);
            //Debug.Log("t is " + t);
            foreach (int num in random)
            {
                if (num == t)
                {
                    //Debug.Log("populate again");
                    allowtoAdd = false;
                    break;
                }
            }
            if (allowtoAdd == true)
            {
                //Debug.Log("n is " + n + "now");
                random.Add(t);
                n = n + 1;
            }

        }
        Debug.Log("CRSerial=" + CRSerial);

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
        if (finishedItem < 5)  //文物上限是5 只允许0 1 2 3 4
        {
            if ((CRSerial == CameraControl.ChoseSerial))
            {
                Debug.Log("Congratulation!");
                Debug.Log(sceneCheck);
                itemCheck = true;
                //myDialog.feedbackDialog(true);
                finishedItem = finishedItem + 1;
                Debug.Log("finished item " + finishedItem);
                //TaskUpload.allowtoAdd = true;

                if (finishedItem == 5)
                {
                    scoring = true;
                    //scroingPage.SetActive(true);
                    autoAdd = false;
                }
                else
                {
                    Debug.Log(RandomSerialNum.index);
                    index = index + 1;
                    CRSerial = random[index];
                    RandomSerialNum.index = RandomSerialNum.index + 1;
                    //myRandom.currentSerial();
                    //CRSerial = myRandom.currentSerial(); // why it can't be called??????????? WTF??/???!?!?!?!?!?!??!?!
                    // you died or still sleeping????????
                    Debug.Log("index = " + RandomSerialNum.index);
                    Debug.Log("CRSerial=" + CRSerial);
                }
                //compare = false; //用来限制是否需要比较选择序列号和文物序列号，若选择正确，则通过compare=false来限制不走elseif
                //autoAdd = true;
                //RandomCR();  //改了random之后文物序列号已经变了 但是选择序列号还没变，所以会直接走else语句 所以会在选对后马上出现选错的提示

                //myDialog.dialogUpload();
            }
            else if ((CRSerial != CameraControl.ChoseSerial))
            {
                itemCheck = false;
                //myDialog.feedbackDialog(false);
                //TaskUpload.allowtoAdd = true;
                Debug.Log("you choose the wrong item！");
                Debug.Log(sceneCheck);
            }
        }
        else  //寄出了所有的文物
        {
            scoring = true;
            //scroingPage.SetActive(true);
            autoAdd = false;
        }
        //TaskUpload.allowtoAdd = true;
        
        Debug.Log("TaskUpload " + TaskUpload.allowtoAdd);

    }
}
