using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSerialNum : MonoBehaviour
{
    public static int CRSerialNum;
    public RandomSerialNum myRandom;
    public List<int> random;
    public static int index = 0;
    public static int CRnum;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        RandomCR();
        currentSerial();
    }

    void Update()
    {
        //if (GameManager.itemCheck == true)
    }

    public void RandomCR() //生成一个不重复的随机数序列
    {
        bool allowtoAdd = false;
        int n = 0;
        while (n < 5)
        {
            //Debug.Log("n is " + n);
            allowtoAdd = true;
            int t = Random.Range(0, 5);
            //Debug.Log("t is " + t);
            foreach (int num in random)
            {
                if (num == t)
                {
                    //Debug.Log("populate again");
                    allowtoAdd = false;
                    break;
                }
            }
            if (allowtoAdd == true)
            {
                //Debug.Log("n is " + n + "now");
                random.Add(t);
                n = n + 1;
            }
        }
        //Debug.Log("CRSerial=" + CRSerial);
    }

    public void currentSerial()
    {
        //CRnum = random[index];
        //GameManager.CRSerial = CRnum;
        Debug.Log("GameManager.CRSerial changed to: " + GameManager.CRSerial);
        
        //return CRnum;
    }


}
