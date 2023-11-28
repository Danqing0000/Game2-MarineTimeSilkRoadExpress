using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecttoPanel : MonoBehaviour
{
    public GameObject panelPage;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Debug.Log("clicked");
        panelPage.SetActive(true);
    }
}
