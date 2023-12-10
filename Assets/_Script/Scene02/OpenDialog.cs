using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialog : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dialogPanel;
    public GameObject feedbackPanel;
    void OnMouseDown()
    {
        if (Dialog.openFeedbackPanel == false)
        {
            dialogPanel.GetComponent<CanvasGroup>().alpha = 1;
            dialogPanel.GetComponent<CanvasGroup>().interactable = true;
        }
    }
}
