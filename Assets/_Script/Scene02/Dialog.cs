using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public List<string> CRRequirement;
    public List<Sprite> character;
    public TMP_Text Content;
    public string currentContent;
    string sentence;
    int stopSerial = 0;
    public Image characterProfile;
    bool test = true;

    public Dialog myDialog;

    public List<string> goodFeedback;
    public List<string> badFeedback;
    public static bool feedback = false;

    public GameObject dialogAll;
    public GameObject dialogPanel;
    public Button tryAgain;
    public Button nextItem;
    public Button nextSentence;
    public static bool openFeedbackPanel = false;

    public void start()
    {
        //print (CRRequirement[GameManager.CRSerial]);
        //Content.text = CRRequirement[GameManager.CRSerial];
    }

    public void Update()
    {
        //Debug.Log("Feedback" + feedback);
        if ((GameManager.sceneCheck == true) && (feedback == true))
        {
            //dialogPanel.SetActive(false);
            feedbackDialog(GameManager.itemCheck);
            feedback = false;
            Debug.Log("Loading");
        }

    }

    public void dialogUpload()  //点击next按键之后才触发这个功能
    {
        currentContent = CRRequirement[GameManager.CRSerial]; //调取对应对话内容
        //dialogPanel.SetActive(true);
        dialogPanel.GetComponent<CanvasGroup>().alpha = 1;
        dialogPanel.GetComponent<CanvasGroup>().interactable = false;
        dialogPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        Debug.Log("Dialog upload");
        if (test == true)
        {
            for (int i = stopSerial; i < currentContent.Length; i++)
            {
                if (currentContent[i] != '/')  //通过/拆分句子，/是句子的结尾
                {
                    sentence = sentence + currentContent[i]; //按照字符增加句子长度
                    //Debug.Log(i);
                }
                else
                {
                    Content.text = sentence;
                    sentence = "";
                    //Debug.Log(i);
                    Debug.Log(sentence);
                    stopSerial = i + 1;
                    //Debug.Log(stopSerial);
                    //Debug.Log("length"+currentContent.Length);
                    break;
                }
            }

            if (stopSerial == currentContent.Length)
            {
                stopSerial = 0;
                test = false; //控制不在结束对话的时候马上跳转到下个场景

                Debug.Log("dialog finish. Change Scene.");

            }
        }
        else // finish upload dialog
        {
            dialogAll.SetActive(false);
            dialogPanel.GetComponent<CanvasGroup>().alpha = 0;
            dialogPanel.GetComponent<CanvasGroup>().interactable = false;
            dialogPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            feedback = true;
            SceneManager.LoadScene("Scene03WarehouseBackup");

        }
    }

    public void feedbackDialog(bool stat) //stat说明事正向反馈or负面反馈
    {
        openFeedbackPanel = true;
        nextItem.gameObject.SetActive(false);
        tryAgain.gameObject.SetActive(false);
        nextSentence.gameObject.SetActive(false);
        if (stat == true)
        {
            Content.text = goodFeedback[Random.Range(0, 3)]; // right item
            nextItem.gameObject.SetActive(true);
        }
        else
        {
            Content.text = badFeedback[Random.Range(0, 3)]; // wrong item
            tryAgain.gameObject.SetActive(true);
        }
    }



}
