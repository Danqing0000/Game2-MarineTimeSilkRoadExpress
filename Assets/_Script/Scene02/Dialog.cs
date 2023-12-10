using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public List<string> CRRequirement;
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
    public ProfileChange myChange;

    public void Update()
    {
        if ((GameManager.sceneCheck == true) && (feedback == true))
        {
            feedbackDialog(GameManager.itemCheck);
            feedback = false;
        }

    }

    public void dialogUpload()  //click next and call the function
    {
        currentContent = CRRequirement[GameManager.CRSerial]; //get the content of the dialog
        dialogPanel.GetComponent<CanvasGroup>().alpha = 1;
        dialogPanel.GetComponent<CanvasGroup>().interactable = false;
        dialogPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if (test == true)
        {
            for (int i = stopSerial; i < currentContent.Length; i++)
            {
                if (currentContent[i] != '/')  // "/" is the end of a sentence
                {
                    sentence = sentence + currentContent[i]; //increase the length of sentence
                }
                else
                {
                    Content.text = sentence;
                    sentence = "";

                    stopSerial = i + 1;
                    break;
                }
            }

            if (stopSerial == currentContent.Length)
            {
                stopSerial = 0;
                test = false; //to make sure that it switch to the next scene after the player clicked next

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

    public void feedbackDialog(bool stat) //stat = true = positive feedback, stat = false = negative feedback
    {
        openFeedbackPanel = true;
        nextItem.gameObject.SetActive(false);
        tryAgain.gameObject.SetActive(false);
        nextSentence.gameObject.SetActive(false);
        myChange.feedbackprofile();
        if (stat == true)
        {
            Content.text = goodFeedback[CameraControl.ChoseSerial]; //CRserial increases if the player chose the right item, but ChoseSerial remains the same.
            nextItem.gameObject.SetActive(true);                    //CRSerial = ChoseSetial if the player chose the right item
        }
        else
        {
            Content.text = badFeedback[GameManager.CRSerial]; //CRserial doesn't increase if chose the wrong item
            tryAgain.gameObject.SetActive(true);
        }
    }



}
