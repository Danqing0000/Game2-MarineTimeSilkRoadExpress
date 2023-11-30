using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CRConfirm : MonoBehaviour
{
    public TMP_Text notice;
    public void confirm()
    {
        if (CameraControl.ChoseSerial == GameManager.CRSerial)
        {
            Debug.Log("1");
            SceneManager.LoadScene("Scene04Workspace");
        }
        else
        {
            notice.text = "Doesn't match";
        }
    }
}
