using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager myGameManager;
    public List<GameObject> RandomCharacter;
    public List<GameObject> CRObjectList; //contain all the antiques
    //public List<List<string>> CRContentList;
    // public List<string> Cube; //contain all the requirements(reception scene), reference(warehouse scene), tasks(workspace scene)
    // public List<string> Sphere; //same as above, name of the lisr = name of the GameObject
    // public List<string> Cylinder;
    // public List<string> Capsule;

    int CharSerial;
    int CRSerial;


    // [System.Serializable]
    // public class CRContent
    // {
    //     public List<string> CR;
    // }

    // [System.Serializable]
    // public class CRContentList
    // {
    //     public List<string> CRListwithContent;
    // }

    // public CRContentList CubeContent = new CRContentList();
    // public CRContentList SphereContent = new CRContentList();
    // public CRContentList CylinderContent = new CRContentList();
    // public CRContentList CapsuleContent = new CRContentList();

    [System.Serializable]
    public class CRs //定义一个新的类 CRs是一个内容为字符串的列表
    {
        public List<string> CRContentList;
    }
    [System.Serializable]
    public class CRList //存储类型为CRs的列表
    {
        public List<CRs> CRLists;
    }


    public CRList listCRList = new CRList();

    public void Start()
    {

    }

    void Awake()
    {
        if (myGameManager == null)
            myGameManager = this;
        else if (myGameManager != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //Debug.Log(this.gameObject.name);
        //RandomChar();
        //RandomCR();
    }

    public void RandomChar()
    {
        RandomCharacter[CharSerial].SetActive(false); //hide original characters
        CharSerial = Random.Range(0, 5);
        Debug.Log("CharSerial=" + CharSerial);
        RandomCharacter[CharSerial].SetActive(true); //show new characters

    }

    public void RandomCR()
    {

        // delete CR after using.
        // use List.length shrink the range of random serial number
        CRObjectList[CRSerial].SetActive(false); //hide original characters
        CRSerial = Random.Range(0, 4);
        Debug.Log("CRSerial=" + CRSerial);
        CRObjectList[CRSerial].SetActive(true); //show new characters
        //CRObjectList.RemoveAt(CRSerial);

        Debug.Log(CRObjectList[CRSerial].name);
        //Debug.Log(CRContentList[CRSerial]);
        Debug.Log(listCRList.CRLists[CRSerial].CRContentList[2]);
    }

}
