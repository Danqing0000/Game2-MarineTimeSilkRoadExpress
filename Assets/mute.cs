using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mute : MonoBehaviour
{
    // Start is called before the first frame update
    bool test = false;
    public List<Sprite> muteicon;
    public void mutebgm()
    {

        if (test == false)
        {
            GameObject.Find("Audio Source").GetComponent<AudioSource>().Pause(); 
            gameObject.GetComponent<Image>().sprite = muteicon[1];
            test = true;
        }
        else
        {
            GameObject.Find("Audio Source").GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Image>().sprite = muteicon[0];
            test = false;
        }
            
    }
}
