using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test2_jun : MonoBehaviour
{
    //JUNHEE_PLMING: 부장님 스크립트(테스트용)
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
                Debug.Log("좋은 아침이다.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.STAIRS:
                Debug.Log("좋은 아점이다.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.TOOL:
                Debug.Log("좋은 점심이다.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.STEAM:
                Debug.Log("좋은 점저이다.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.SLOW:
                Debug.Log("좋은 저녁이다.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.BOOM:
                Debug.Log("좋은 저밤이다.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            case Test3_jun_move.Action_statu.DOWN:
                Debug.Log("좋은 밤이다.");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
            default:
                Debug.Log("끝");
                Test3_jun_move.ai_chars_ready[0] = true;
                time = 0;
                break;
        }

    }


}
