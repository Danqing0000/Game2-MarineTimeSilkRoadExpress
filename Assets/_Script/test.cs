using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public TaskUpdate myUpdate;
    
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        Debug.Log("Maginify clicked");
        myUpdate.finishStateCheck(3);
    }
}
