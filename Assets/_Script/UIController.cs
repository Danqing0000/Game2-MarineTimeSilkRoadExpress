using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject panelPage;


     public void closePanel(string panelName)
    {
        panelPage = GameObject.Find(panelName);
        panelPage.SetActive(false);
    }
}
