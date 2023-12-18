using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Smoke : MonoBehaviour
{
    public Button[] interaction_button = new Button[3];
    public GameObject guidance_text;
    public Test_jun camera_jun;
    bool button_start = false;
    // Start is called before the first frame update
    void Start()
    {
        interaction_button[0].onClick.AddListener(() =>
        {
            if (!button_start)
            {
                for (int i = 0; i < interaction_button.Length; i++)
                {
                    interaction_button[i].interactable = false;
                }
                button_start = true;
                StartCoroutine(Test());
            }
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Test()
    {
        while (camera_jun.in_or_out != 1)
        {
            camera_jun.in_or_out = Mathf.Clamp(camera_jun.in_or_out - Time.deltaTime * 20, 1, 5);
            yield return null;
        }
        yield return new WaitForSeconds(5);
        while (camera_jun.in_or_out != 5)
        {
            camera_jun.in_or_out = Mathf.Clamp(camera_jun.in_or_out + Time.deltaTime * 20, 1, 5);
            yield return null;
        }
        button_start = false;
        for (int i = 1; i < interaction_button.Length; i++)
        {
            interaction_button[i].interactable = true;
        }
    }
}
