using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repair : MonoBehaviour
{
    public TaskUpdate myUpdate;
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnMouseDown()
    {
        Debug.Log("Maginify clicked");
        animator.SetTrigger("glue");
        myUpdate.finishStateCheck(3);
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
