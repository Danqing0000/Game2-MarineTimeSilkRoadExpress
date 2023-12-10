using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintChange : MonoBehaviour
{
    public List<Sprite> hint;
    public Image imagehint;
    public HintChange myhint;

    public void hintchange()
    {
        imagehint.sprite = hint[GameManager.CRSerial];
    }
}
