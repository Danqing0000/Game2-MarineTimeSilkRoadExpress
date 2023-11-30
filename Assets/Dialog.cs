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

    public void start()
    {
        //print (CRRequirement[GameManager.CRSerial]);
        //Content.text = CRRequirement[GameManager.CRSerial];

    }

    public void dialogUpload()
    {
        currentContent = CRRequirement[GameManager.CRSerial]; //调取对应对话内容
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
                    //Debug.Log(sentence);
                    stopSerial = i + 1;
                    //Debug.Log(stopSerial);
                    //Debug.Log("length"+currentContent.Length);
                    break;
                }
            }

            if (stopSerial == currentContent.Length)
            {
                stopSerial = 0;
                test = false;
                Debug.Log("dialog finish. Change Scene.");
                
            }
        }
        else
        {
            SceneManager.LoadScene("Scene04Workspace");
        }


    }
}
