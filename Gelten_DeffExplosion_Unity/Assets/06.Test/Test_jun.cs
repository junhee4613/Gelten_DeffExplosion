using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//time.timescale¿∫ ƒ⁄∑Á∆æ Ω·µµ ∏ÿ√·¥Ÿ.
public class Test_jun : MonoBehaviour
{
    [Range(1, 5)]
    public float in_or_out;
    public Camera main_camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        main_camera.fieldOfView = in_or_out * 12;
    }
}
