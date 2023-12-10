using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject panelPage;

    public void openPanel(string panelName)
    {
        panelPage = GameObject.Find(panelName);
        panelPage.SetActive(true);
    }
    
    public void closePanel(string panelName)
    {
        panelPage = GameObject.Find(panelName);
        panelPage.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }

    public void Play(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

}
