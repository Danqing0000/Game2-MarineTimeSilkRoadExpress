using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CRConfirm : MonoBehaviour
{
    public TMP_Text notice;
    public GameManager myManager;
    public void confirm()
    {
        //notice.text = "Is that what he/ she wants?";
        // if (CameraControl.ChoseSerial == GameManager.CRSerial)
        // {
            //Debug.Log("1");
            SceneManager.LoadScene("Scene04Workspace");
            TaskUpload.allowtoAdd = true;
            Debug.Log("Camera control changed addlist to " + TaskUpload.allowtoAdd);
            //myManager.taskUpload();
        //}
        // else
        // {
        //     notice.text = "Doesn't match";
        // }
    }

    public void contentUpdate() 
    {
        notice.text = "Is that what he/ she wants?";
    }
}
