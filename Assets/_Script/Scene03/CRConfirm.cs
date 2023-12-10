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
            SceneManager.LoadScene("Scene04Workspace");
            TaskUpload.allowtoAdd = true;
            Debug.Log("Camera control changed addlist to " + TaskUpload.allowtoAdd);
    }

    public void contentUpdate() 
    {
        notice.text = "Is that what he wants?";
    }
}
