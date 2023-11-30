using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileChange : MonoBehaviour
{
    
    public List<Sprite> character;
    public List<string> description;
    public Image characterProfile;
    public TMP_Text Caller;
    // Start is called before the first frame update
    public void Start()
    {
        characterProfile.sprite = character[GameManager.CRSerial];
        Caller.text = description[GameManager.CRSerial];
        Debug.Log(GameManager.CRSerial);
    }

    // Update is called once per frame
    
}
