using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//time.timescale�� �ڷ�ƾ �ᵵ �����.
public class Test_jun : MonoBehaviour
{
    [Range(5, 10)]
    public float in_or_out;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Test()
    {
        Debug.Log("���� ��ħ�Դϴ�.");
        yield return new WaitForSeconds(2);
        Debug.Log("���� ��ħ�Դϴ�.");
        yield return new WaitForSeconds(2);
        Debug.Log("���� ��ħ�Դϴ�.");
        yield return new WaitForSeconds(2);
        Debug.Log("���� ��ħ�Դϴ�.");
        yield return new WaitForSeconds(2);
        Debug.Log("���� ��ħ�Դϴ�.");
        yield return new WaitForSeconds(2);
        Debug.Log("���� ��ħ�Դϴ�.");
        yield return new WaitForSeconds(2);

    }
}
