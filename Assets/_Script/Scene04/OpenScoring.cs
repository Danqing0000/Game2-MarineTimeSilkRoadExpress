using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScoring : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("model").GetComponent<AudioSource>().enabled = true;
    }
    void Update()
    {
        if (GameManager.scoring == true)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            gameObject.GetComponent<CanvasGroup>().interactable = true;
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            GameObject.Find("model").GetComponent<AudioSource>().enabled = false;
        }
    }
    public void clearScoring()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void scoringCheck()
    {
        if (GameManager.finishedItem == 5)
            GameManager.scoring = true;
    }
}
