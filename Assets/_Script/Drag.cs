using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    //https://www.youtube.com/watch?v=pFpK4-EqHXQ 

    Vector3 mousePosition;
    float finalX, finalY, finalZ;

    private void Start()
    {
        float finalZ = transform.position.z;
        Debug.Log("finalZ=" + finalZ);
    }
    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);

    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        //Debug.Log(mousePosition);
        //Debug.Log(mousePosition.x);
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition + new Vector3 (1.5f,1.5f,1f)));
        finalX = Input.mousePosition.x - mousePosition.x;
        finalY = Input.mousePosition.y - mousePosition.y;
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (finalX, finalY, 0));
        // Debug.Log(finalX);
        // Debug.Log(finalY)
    }

}