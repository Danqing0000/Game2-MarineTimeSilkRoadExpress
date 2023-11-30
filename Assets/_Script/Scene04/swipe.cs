using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    Vector3 m_startPos;
    Vector3 m_endPos;
    Animator animator;
    //bool mouseState = false;
    int test;
    Collider myCollider;
    bool finished = false;

    public TaskUpdate myUpdate;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
        test = 0;
        myCollider = GetComponent<Collider>();
    }

    void OnMouseDown()
    {   
        if (finished == false)
        {
            animator.SetTrigger("pickup");
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            m_startPos = Input.mousePosition;
            //Debug.Log("Start" + m_startPos);
        }
    }

    
    void OnMouseUp()
    {
        m_endPos = Input.mousePosition;
        //Debug.Log(m_endPos);
        MousePositionCkeck();
        FinishTest(test);
    }

    void MousePositionCkeck()
    {
        if (m_startPos.x - m_endPos.x < 0)
        {
            //Debug.Log(m_startPos + "&" + m_endPos + "&" +"Left");
            //myAnimation.clip = left;
            //myAnimation.Play(0);
            // animator.SetBool("left", true);
            // StartCoroutine(CoundDown(5));
            // animator.SetBool("left", false);
            animator.SetTrigger("left");
            test = test +1;
            

        }
        else if (m_startPos.x - m_endPos.x > 0)
        {
            //Debug.Log(m_startPos + "&" + m_endPos + "&" +"Right");
            // myAnimation.clip = right;
            // myAnimation.Play(1);
            //animator.SetBool("right", true);
            animator.SetTrigger("right");
            test = test +1;
            
        }
        //Debug.Log(test);
        
    }

    IEnumerator CoundDown(int time)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    void FinishTest(int testnum)
    {
        if (testnum == 6)
        {
            animator.SetBool("test", true);
            Debug.Log("done");
            //StartCoroutine(CoundDown(5));
            myCollider.enabled =! myCollider.enabled;
            finished = true;
            myUpdate.finishStateCheck(3);
        }
    }


}
