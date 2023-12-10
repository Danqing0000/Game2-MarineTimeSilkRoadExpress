using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjecttoPanel : MonoBehaviour
{
    public GameObject panelPage;
    public GameObject panelPage2;
    public TaskUpdate myUpdate;
    public GameObject next;

    void OnMouseDown()
    {
        if ((this.name == "palette"))
        {
            if (CameraControl.ChoseSerial == 3)
                panelPage.SetActive(true);
            else if (CameraControl.ChoseSerial == 4)
                panelPage2.SetActive(true);
        }
        else if ((this.name == "package") && (myUpdate.CheckAll(5) == true))
        {
            panelPage.SetActive(true);
        }
        else if ((this.name != "package") && (this.name != "palette"))
        {
            panelPage.SetActive(true);
        }
        else if (this.name == "model") // telephone
        {
            panelPage.SetActive(true);
            next.SetActive(true);
        }
    }
}
