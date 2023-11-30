using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TaskUpdate : MonoBehaviour
{
    public List<TMP_Text> taskeach; // change color after finish the task
    public TaskUpdate myUpdate;
    public List<bool> taskCheck; //单项任务是否完成
    public List<GameObject> tools;
    public List<bool> finishState;
    public int taskTotalNum;
    public bool finalState; //所有任务的完成情况

    public void Start()
    {
        //Debug.Log(GameManager.listCRList.CRLists[GameManager.CRSerial].CRContentList[2]);
        //GameManager.
    }

    public void getTotalTaskNum(int x)
    {
        taskTotalNum = x;
        Debug.Log("total number" + x);
    }

    public void getTaskBool(int y, bool state)
    {
        Debug.Log("number" + y);
        //Debug.Log(state);
        taskCheck[y] = state;

        tools[y].GetComponent<Collider>().enabled = state;
        Debug.Log(tools[y].GetComponent<Collider>().enabled);
    }

    public void finishStateCheck(int serialnumber)
    {
        finishState[serialnumber] = true;
        taskeach[serialnumber].color = Color.gray;
    }

    public bool CheckAll()
    {
        finalState = true;
        for (int i = 1; i <=4; i++)
        {
            if (finishState[i] == false)
            {
                //Debug.Log("List " + (i+1) +" hasn't been finished!");
                finalState = false;
                i = i-1; //阻止i递增 确保一直按照顺序完成
                break;
            }
        }

        return finalState;
    }
}
