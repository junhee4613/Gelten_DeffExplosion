using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//time.timescale�� �ڷ�ƾ �ᵵ �����.
public class Test_jun : MonoBehaviour
{
    public float in_or_out = 10;
    public Camera main_camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        main_camera.fieldOfView = in_or_out * 6;
    }
}
