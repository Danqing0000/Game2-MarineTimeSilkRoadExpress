using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager myGameManager;
    public List<GameObject> RandomCharacter;
    int CharSerial;

    void Awake()
    {
        if (myGameManager == null)
            myGameManager = this;
        else if (myGameManager != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //Debug.Log(this.gameObject.name);
        RandomChar();
    }

    public void RandomChar()
    {
        RandomCharacter[CharSerial].SetActive(false); //hide original characters
        CharSerial = Random.Range(0, 4);
        Debug.Log(CharSerial);
        RandomCharacter[CharSerial].SetActive(true); //show new characters
    }

    public void RandomTasks()
    {

    }

}
