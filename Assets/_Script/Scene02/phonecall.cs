using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phonecall : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> phone;
    public AudioSource myAudio;
    public void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
        myAudio.clip = phone[0];
        StartCoroutine(WaitAndDoSomething()); 
        //myAudio.Play();
    }

    private void OnMouseDown()
    {
        myAudio.Stop();
        myAudio.clip = phone[1];
        myAudio.Play();
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(3f);
        myAudio.Play(); 
    }
}
