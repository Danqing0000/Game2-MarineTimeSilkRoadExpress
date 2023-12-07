using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileChange : MonoBehaviour
{
    public ProfileChange myChange;
    public List<Sprite> character;
    public List<string> description;
    public List<string> callingPlace;
    public Image characterProfile;
    public TMP_Text Caller;
    public TMP_Text Place;
    // Start is called before the first frame update
    public void profile()
    {
        characterProfile.sprite = character[GameManager.CRSerial];
        Caller.text = description[GameManager.CRSerial];
        Place.text = callingPlace[GameManager.CRSerial];
        Debug.Log(GameManager.CRSerial);
    }

    public void feedbackprofile()
    {
        if (GameManager.itemCheck == true)
        {
            characterProfile.sprite = character[CameraControl.ChoseSerial];
            Caller.text = description[CameraControl.ChoseSerial];
            Place.text = callingPlace[CameraControl.ChoseSerial];
            Debug.Log(CameraControl.ChoseSerial);
        }
        else
        {
            characterProfile.sprite = character[GameManager.CRSerial];
            Caller.text = description[GameManager.CRSerial];
            Place.text = callingPlace[GameManager.CRSerial];
            Debug.Log(GameManager.CRSerial);
        }
    }

}
