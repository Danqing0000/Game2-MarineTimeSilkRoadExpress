using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;


public class nameConfirm : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField serialInput;
    public TMP_Text notice;


    public void inputCheck()
    {
        if ((serialInput.text == "ASD1234") && (nameInput.text == "11111"))
        {
            Debug.Log("ok");
            notice.text = "correct";
            SceneManager.LoadScene("Scene00Start");
        }
        if ((serialInput.text != "ASD1234") || (nameInput.text != "11111"))
        {
            notice.text = "input wrong";
            Debug.Log("wrong");
        }
        if ((serialInput.text == "") || (nameInput.text == "")) //it's not null!!!
        {
            notice.text = "please input";
            Debug.Log("input incomplete");
        }
    }
}
