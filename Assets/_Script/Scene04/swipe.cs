using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    Vector3 m_startPos;
    Vector3 m_endPos;
    Animator animator;
    int test;
    Collider myCollider;
    bool finished = false;

    public TaskUpdate myUpdate;

    private void Start()
    {
        animator = GetComponent<Animator>();
        test = 0;
        myCollider = GetComponent<Collider>();
    }

    void OnMouseDown()
    {   
        if ((finished == false) && (myUpdate.CheckAll(3)))
        {
            animator.SetTrigger("pickup");
        }
        if (Input.GetMouseButtonDown(0))
        {
            m_startPos = Input.mousePosition;
        }
    }

    
    void OnMouseUp()
    {
        m_endPos = Input.mousePosition;
        MousePositionCkeck();
        FinishTest(test);
    }

    void MousePositionCkeck()
    {
        if ((m_startPos.x - m_endPos.x < 0) && (myUpdate.CheckAll(3)))
        {
            animator.SetTrigger("left");
            gameObject.GetComponent<AudioSource>().Play();
            test = test +1;
        }
        else if ((m_startPos.x - m_endPos.x > 0) && (myUpdate.CheckAll(3)))
        {
            animator.SetTrigger("right");
            gameObject.GetComponent<AudioSource>().Play();
            test = test +1;
        }
    }

    void FinishTest(int testnum)
    {
        if (testnum == 3)
        {
            animator.SetBool("test", true);
            myCollider.enabled =! myCollider.enabled;
            finished = true;
            myUpdate.finishStateCheck(4);
        }
    }
}
