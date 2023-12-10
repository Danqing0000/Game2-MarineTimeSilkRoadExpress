using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class matchcolor : MonoBehaviour
{
    public int color_record;
    public List<buttonimage> changepiece;
    public List<Sprite> clearimageList;
    public List<bool> changeornot; //if the color is changed
    public bool colorFinalState = false;
    public TaskUpdate myUpdate;
    public GameObject coloringPanel;

    public void getColor(int Button_color)
    {
        color_record = Button_color;
        //record the color chosen
    }

    public void setColor(int matchnum)
    {
        changepiece[matchnum].changeButtonImage(color_record, matchnum);
        changeornot[matchnum] = true;
        //set color to specific match piece.
        //matchnum = serial number of match pieces
        //color_record = serial number of colors
        //changeButtonImage: attached on match pieces, change the sprite image.
    }

    public void checkAllColor() //check if all the blanks has been coloured.
    {
        if ((changeornot[0] == true) && (changeornot[1] == true) && (changeornot[2] == true))
        {
            colorFinalState = true;
            myUpdate.finishStateCheck(2);
        }
    }

    public void clearAll()
    {
        int i = 0;
        foreach (var piece in changepiece)
        {
            piece.GetComponent<Button>().image.sprite = clearimageList[i];
            changeornot[i] = false;
            colorFinalState = false;
            i = i + 1;
        }
    }

    public void submit()
    {   
        checkAllColor();
        if (colorFinalState == true)
        {
            coloringPanel.SetActive(false);
            
        }
        else
            Debug.Log("haven't finish yet");
    }
}
