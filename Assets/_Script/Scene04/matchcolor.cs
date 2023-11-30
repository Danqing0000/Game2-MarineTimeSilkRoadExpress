using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class matchcolor : MonoBehaviour
{
    public int color_record;
    public List<buttonimage> changepiece;
    public List<Sprite> clearimageList;
    public List<bool> changeornot; //记录颜色是否改变
    public bool colorFinalState = false;
    public TaskUpdate myUpdate;
    public GameObject coloringPanel;

    public void getColor(int Button_color)
    {
        Debug.Log(Button_color);
        color_record = Button_color;
        //record the color chosen
    }

    public void setColor(int matchnum)
    {
        changepiece[matchnum].changeButtonImage(color_record, matchnum);
        Debug.Log("color_record" + color_record + "matchnum" + matchnum);
        changeornot[matchnum] = true;
        checkAllColor();
        //set color to specific match piece.
        //matchnum = serial number of match pieces
        //color_record = serial number of colors
        //changeButtonImage: attached on match pieces, change the sprite image.
    }

    public void checkAllColor()
    {
        if ((changeornot[0] == true) && (changeornot[1] == true) && (changeornot[2] == true))
        {
            colorFinalState = true;
            myUpdate.finishStateCheck(1);
            Debug.Log("color all");
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

        //button1.image.sprite = Resources.Load<Sprite>("leaf");
    }

    public void submit()
    {
        if (colorFinalState == true)
        {
            coloringPanel.SetActive(false);
        }
        else
            Debug.Log("haven't finish yet");
    }
}
