using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InteractionScripts
{
    public InteractionActions actions;
    public abstract void Init(UnityEngine.Object obj);
    //누른 순간 1회 발동
    protected void afterInit(UnityEngine.Object obj)
    {
        PlayerController PC = obj as PlayerController;
        switch (actions)
        {
            case InteractionActions.none:
                break;
            case InteractionActions.climbing:
                UnityEngine.Object[] tempOBJ = new UnityEngine.Object[1];
                tempOBJ[0] = PC;
                _init(tempOBJ);
                break;
            case InteractionActions.removeStatic:
                // TODO : 정전기 제거 스크립트 구현 시 해당 스크립트 작업 필요
                break;
            case InteractionActions.grabItem:
                // TODO : 그랩 아이템 스크립트 구현 시 해당 스크립트 작업 필요
                break;
        }
    }
    //init이후 작동
    protected abstract void _init(UnityEngine.Object[] OBJ);
    //afterInit이후 작동
    protected abstract void Interaction(Vector3 updatedVec);
    //누르고 있는동안 작동
    public abstract void outIt();
    //키를 땔때 작동
}
public class Climbing : InteractionScripts
{
    private Transform playerTR;
    private Rigidbody playerRB;
    private Vector3 grabStartPos;
    public override void Init(UnityEngine.Object obj)
    {
        if (playerTR == null ||playerRB == null)
        {
            actions = InteractionActions.climbing;
            afterInit(obj);
        }
    }
    protected override void _init(UnityEngine.Object[] obj)
    {
        PlayerController tempPC = obj[0] as PlayerController;
        playerTR = tempPC.transform;
        playerRB = tempPC.rb;
        grabStartPos = tempPC.grapStartPosition;

        playerRB.useGravity = false;
    }
    protected override void Interaction(Vector3 updatedVec)
    {
        if (playerTR == null || playerRB == null)
        {
            return;
        }
        else if (playerTR != null && playerRB != null)
        {
            playerTR.position += grabStartPos - updatedVec;
        }
    }
    public override void outIt()
    {
        playerRB.useGravity = true;
        playerTR = null;
        playerRB = null;
        grabStartPos = Vector3.zero;
    }
}
public enum InteractionActions
{
    none,climbing,removeStatic,grabItem
}
