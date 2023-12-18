using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InteractionScripts
{
    public InteractionActions actions;
    public abstract void Init(UnityEngine.Object obj);
    //���� ���� 1ȸ �ߵ�
    protected void afterInit(UnityEngine.Object obj)
    {
        PlayerController PC = obj as PlayerController;
        switch (actions)
        {
            case InteractionActions.none:
                break;
            case InteractionActions.climbing:
                UnityEngine.Object[] tempOBJ = new UnityEngine.Object[2];
                tempOBJ[0] = PC.transform;
                tempOBJ[1] = PC.rb;
                _init(tempOBJ);
                break;
            case InteractionActions.removeStatic:
                break;
            case InteractionActions.grabItem:
                break;
        }
    }
    //init���� �۵�
    protected abstract void _init(UnityEngine.Object[] OBJ);
    //afterInit���� �۵�
    protected abstract void Interaction(Vector3 updatedVec);
    //������ �ִµ��� �۵�
    public abstract void outIt();
    //Ű�� ���� �۵�
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
        playerTR = obj[0] as Transform;
        playerRB = obj[1] as Rigidbody;
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
    }
}
public enum InteractionActions
{
    none,climbing,removeStatic,grabItem
}
