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
    public Image file;

    public void OnMouseDown()
    {
        animator.SetTrigger(triggerName);
        Debug.Log("move to " + triggerName);
        ChoseSerial = choseNow;
        gameObject.GetComponent<AudioSource>().Play();

        file.sprite = fileList[CameraControl.ChoseSerial];
        GameManager.AddList = true;
        GameManager.sceneCheck = true;
    }
}
