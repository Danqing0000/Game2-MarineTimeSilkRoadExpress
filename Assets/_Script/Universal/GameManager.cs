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
    public static int CRSerial = 0;
    public static bool sceneCheck = true;
    public List<int> random;
    //public Dialog myDialog;
    public static int finishedItem = 0; //the cultural ralics that have been post successfully
    public static bool itemCheck; //if the player found the right item
    public static bool scoring = false;
    public static bool AddList = true;
    


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

    void Awake()
    {
        if (myGameManager == null)
            myGameManager = this;
        else if (myGameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if ((SceneManager.GetActiveScene().name == "Scene00Start"))
        {
            CRSerial = 0;
            finishedItem = 0;
            scoring = false;
        }
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

            AddList = false;
        }
        if ((SceneManager.GetActiveScene().name == "Scene04Workspace") && (sceneCheck == true))
        {
            taskUpload();
        }

    }

    public void RandomCR() //This has not been used
    {
        bool allowtoAdd = false;
        int n = 0;
        while (n < 5)
        {
            allowtoAdd = true;
            int t = Random.Range(0, 5);
            foreach (int num in random)
            {
                if (num == t)
                {
                    allowtoAdd = false;
                    break;
                }
            }
            if (allowtoAdd == true)
            {
                random.Add(t);
                n = n + 1;
            }
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
            if (listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[i] == "/")
            {
                update.setTaskBool(i, false);
                update.finishState[i] = true;
                
            }
            else
            {
                taskeach[taskSerialRecord].text = listCRList.CRLists[CameraControl.ChoseSerial].CRContentList[i];  
                taskSerialRecord++;
                update.setTaskBool(i, true);
                update.getTotalTaskNum(taskSerialRecord);
            }
        }
        sceneCheck = false;
    }

    public void finalItemCheck()  //final check. If the player chose a wrong item, he will receive a negative feedback
    {
        if (finishedItem < 5)  //total number od items is 5
        {
            if ((CRSerial == CameraControl.ChoseSerial))
            {
                itemCheck = true;
                finishedItem = finishedItem + 1;
                Debug.Log(finishedItem);
                if (finishedItem != 5)
                {
                    CRSerial = CRSerial + 1;
                }
            }
            else if ((CRSerial != CameraControl.ChoseSerial))
            {
                itemCheck = false;
            }
        }
    }
}
