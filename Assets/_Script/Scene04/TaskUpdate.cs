using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TaskUpdate : MonoBehaviour
{
    public List<TMP_Text> taskeach; // change color after finish the task
    public TaskUpdate myUpdate;
    public List<bool> taskCheck; //if the single task is finished
    public List<GameObject> tools;
    public List<bool> finishState;
    public int taskTotalNum;
    public bool finalState; //if all the tasks are finished
    public bool currentTaskState;
    public int a = 2;

    public void getTotalTaskNum(int x)
    {
        taskTotalNum = x;
    }

    public void setTaskBool(int y, bool state) //recore total task
    {
        taskCheck[y] = state;
        tools[y].GetComponent<Collider>().enabled = state;
    }

    public void finishStateCheck(int serialnumber)
    {
        finishState[serialnumber] = true;
        taskeach[a-1].color = Color.gray;
        gameObject.GetComponent<AudioSource>().Play();
        a = a + 1;
        if (serialnumber == 5)
            a = 2;
    }

    public bool CheckAll(int currentid)
    {
        finalState = true;
        for (int i = 0; i < currentid; i++)
        {
            currentTaskState = taskCheck[currentid];
            if ((currentTaskState == true) && (finishState[i] == false)) //taskstate: if the player need to do the task; finishState: if the tasks have been finished
            {
                Debug.Log("previous unfinish");
                finalState = false;
                break;
            }
            else if (currentTaskState == false)
            {
                finishState[i] = true;
            }
        }
        Debug.Log(finalState);
        return finalState; // finalstate = true, previous tasks have been finished; finalstate = false, previous tasks haven't finished
    }
}