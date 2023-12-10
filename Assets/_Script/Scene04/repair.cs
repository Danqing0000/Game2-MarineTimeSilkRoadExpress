using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repair : MonoBehaviour
{
    public TaskUpdate myUpdate;
    AudioSource myAudio;
    
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void OnMouseDown()
    {
        myAudio.Play();
        myUpdate.finishStateCheck(3);
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
