using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class Test3_jun_move : MonoBehaviour
{
    //JUNHEE_PLMING: 상황 중계기 스크립트(테스트용)
    public static bool[] ai_chars_ready = new bool[3] {false, true, true };
    public static bool story_skip = false;
    public static Action_statu statu = Action_statu.INIT;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (All_ai_character_ready())
        {
            statu = (Action_statu)(((int)statu + 1) % Enum.GetValues(typeof(Action_statu)).Length);
            Debug.Log((int)statu);

        }
    }
    public enum Action_statu
    {
        INIT,
        STAIRS,
        TOOL,
        STEAM,
        SLOW,
        BOOM,
        DOWN
    }
    public bool All_ai_character_ready()
    {
        if(ai_chars_ready[0] && ai_chars_ready[1] && ai_chars_ready[2])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
