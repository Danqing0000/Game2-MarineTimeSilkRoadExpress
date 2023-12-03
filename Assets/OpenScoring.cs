using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScoring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.scoring == true)
        {
            gameObject.SetActive(true);
        }
    }
}
