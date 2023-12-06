using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScoring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.scoring == true)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            gameObject.GetComponent<CanvasGroup>().interactable = true;
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            //Debug.Log("Scoring opened already");
        }
    }
}
