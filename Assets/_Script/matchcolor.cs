using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class matchcolor : MonoBehaviour
{
    public int color_record;
    public List<buttonimage> changepiece;
    public List<Sprite> clearimageList;

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

        //set color to specific match piece.
        //matchnum = serial number of match pieces
        //color_record = serial number of colors
        //changeButtonImage: attached on match pieces, change the sprite image.
    }

    public void clearAll()
    {
        int i = 0;
        foreach (var piece in changepiece)
        {
            piece.GetComponent<Button>().image.sprite = clearimageList[i];
            i = i + 1;
        }
            
        //button1.image.sprite = Resources.Load<Sprite>("leaf");
    }
}
