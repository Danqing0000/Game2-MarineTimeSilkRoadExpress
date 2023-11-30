using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjecttoPanel : MonoBehaviour
{
    public GameObject panelPage;

    void OnMouseDown()
    {
        Debug.Log("clicked");
        panelPage.SetActive(true);
        
    }
}
