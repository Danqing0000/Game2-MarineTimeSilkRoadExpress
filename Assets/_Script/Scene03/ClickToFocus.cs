using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToFocus : MonoBehaviour
{
    public Camera myCamera;
    void Update()
    {
         if(Input.GetMouseButtonDown(0))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                myCamera.transform.position = clickedObject.transform.position - myCamera.transform.forward * 5f;

                myCamera.transform.LookAt(clickedObject.transform.position);
            }
        }
    }
}
