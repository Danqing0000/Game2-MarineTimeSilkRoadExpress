using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonimage : MonoBehaviour
{
    Image myImage;
    public List<Sprite> imageList; 
    public List<Button> buttonList;
    public buttonimage buttonimagechange;
    

    void Awake()
    {
        myImage = GetComponent<Image>();
    }

    void Start()
    {
        myImage.alphaHitTestMinimumThreshold = 0.1f;
        //make sure the activate area of the button follows the shape of the image
    }

    public void changeButtonImage (int t, int matchnum)
    {
        buttonList[matchnum].image.sprite = imageList[t];
        //change the sprite image of specific match piece
    }
}
