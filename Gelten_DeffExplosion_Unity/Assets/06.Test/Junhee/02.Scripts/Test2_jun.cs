using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test2_jun : MonoBehaviour
{
    //JUNHEE_PLMING: ����� ��ũ��Ʈ(�׽�Ʈ��)
    public Animator an;
    public Rigidbody rb;
    public NavMeshAgent agent;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 3)
        {
            Story_situation();
        }
        else
        {
            time += Time.deltaTime;
        }
    }
    public void Story_situation()
    {
        switch (Test3_jun_move.statu)
        {
            case Test3_jun_move.Action_statu.INIT:
                Debug.Log("���� ��ħ�̴�.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.STAIRS:
                Debug.Log("���� �����̴�.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.TOOL:
                Debug.Log("���� �����̴�.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.STEAM:
                Debug.Log("���� �����̴�.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.SLOW:
                Debug.Log("���� �����̴�.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.BOOM:
                Debug.Log("���� �����̴�.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.DOWN:
                Debug.Log("���� ���̴�.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            default:
                Debug.Log("��");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
        }

    }


}
