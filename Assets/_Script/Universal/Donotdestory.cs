using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donotdestory : MonoBehaviour
{
    public Donotdestory myAudio;
    void Awake()
    {
        if (myAudio == null)
            myAudio = this;
        else if (myAudio != this)
            Destroy(gameObject);
            
        DontDestroyOnLoad(gameObject);
    }
}
