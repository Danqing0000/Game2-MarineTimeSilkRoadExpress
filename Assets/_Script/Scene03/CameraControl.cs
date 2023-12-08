using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public Animator animator;

    public string triggerName;
    public static int ChoseSerial;
    public int choseNow;
    public List<Sprite> fileList;
    public List<Sprite> picList;
    public List<Sprite> noteList;
    public Image file;
    public Image pic;
    public Image note;

    public void OnMouseDown()
    {
        animator.SetTrigger(triggerName);
        Debug.Log("move to " + triggerName);
        ChoseSerial = choseNow;
        gameObject.GetComponent<AudioSource>().Play();
        //Debug.Log(ChoseSerial);

        file.sprite = fileList[CameraControl.ChoseSerial];
        pic.sprite = picList[CameraControl.ChoseSerial];
        note.sprite = noteList[CameraControl.ChoseSerial];
        GameManager.AddList = true;
        GameManager.sceneCheck = true;
    }
}
