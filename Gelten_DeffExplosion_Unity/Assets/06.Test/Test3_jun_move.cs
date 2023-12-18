using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3_jun_move : MonoBehaviour
{
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position += transform.forward * Time.deltaTime;
    }
}
