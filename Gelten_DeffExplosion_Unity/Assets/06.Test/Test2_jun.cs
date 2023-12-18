using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_jun : MonoBehaviour
{
    public bool dlrj = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dlrj)
        {
            Time.timeScale = 0;
        }
    }
}
