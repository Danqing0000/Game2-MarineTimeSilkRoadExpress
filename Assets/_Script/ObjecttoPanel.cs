using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjecttoPanel : MonoBehaviour
{
    public GameObject panelPage;
    public TaskUpdate myUpdate;

    void OnMouseDown()
    {
        if ((this.name == "palette") && (myUpdate.CheckAll(2) == true))
        {
            panelPage.SetActive(true);
        }
        else if ((this.name == "package") && (myUpdate.CheckAll(5) == true))
        {
            panelPage.SetActive(true);
        }
        else if ((this.name != "package") && (this.name != "palette"))
        {
            panelPage.SetActive(true);
        }
        
        
        
        
        Debug.Log("clicked");
        //panelPage.SetActive(true);
        Debug.Log(this.name); //using the name to switch
    }
}
