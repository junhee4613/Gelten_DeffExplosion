using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public abstract class InteractionScripts
{
    public InteractionActions actions;
    public InteractionDetailPosition detail;
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
                UnityEngine.Object[] tempOBJ = new UnityEngine.Object[1];
                tempOBJ[0] = PC;
                _init(tempOBJ);
                break;
            case InteractionActions.removeStatic:
                // TODO : ������ ���� ��ũ��Ʈ ���� �� �ش� ��ũ��Ʈ �۾� �ʿ�
                break;
            case InteractionActions.grabItem:
                // TODO : �׷� ������ ��ũ��Ʈ ���� �� �ش� ��ũ��Ʈ �۾� �ʿ�
                break;
        }
    }
    //init���� �۵�
    protected abstract void _init(UnityEngine.Object[] OBJ);
    //afterInit���� �۵�
    public void InteractionCon(Vector3 playerPos,Vector3 updatedVec)
    {

        if (isOverlab(playerPos))
        {
            Interaction(updatedVec);
        }
    }
    public abstract void Interaction(Vector3 updatedVec);
    //������ �ִµ��� �۵�
    public abstract void outIt();
    //Ű�� ���� �۵�
    bool isOverlab(Vector3 PlayerPos)
    {
        Vector3 tempVec = byteTOFloatedVector(detail.x, detail.y, detail.z);
        Vector3 floatOnlyPlrPos = new Vector3(PlayerPos.x % 1, PlayerPos.y % 1, PlayerPos.z % 1);
        if (floatOnlyPlrPos.x>= tempVec.x-(detail.size.x/2)&& floatOnlyPlrPos.y >= tempVec.y - (detail.size.y / 2) && floatOnlyPlrPos.z >= tempVec.z - (detail.size.z / 2)
            && floatOnlyPlrPos.x<= tempVec.x+(detail.size.x/2)&& floatOnlyPlrPos.y <= tempVec.y + (detail.size.y / 2) && floatOnlyPlrPos.z <= tempVec.z + (detail.size.z / 2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    Vector3 byteTOFloatedVector( byte detailX, byte detailY, byte detailZ)
    {
        Vector3 ConvertedValue = new Vector3(detailX - 128, detailY - 128, detailZ - 128);
        ConvertedValue = (new Vector3(ConvertedValue.x / 128f, ConvertedValue.y / 128f, ConvertedValue.z / 128f));

        return ConvertedValue;
    }
}
[System.Serializable]
public class Climbing : InteractionScripts
{
    private Transform playerTR;
    private Rigidbody playerRB;
    private float grabStartPos;
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
        tempPC.rb.velocity = Vector3.zero;
        playerTR = tempPC.transform;
        playerRB = tempPC.rb;
        grabStartPos = tempPC.grapStartPosition;
        //TODO : grabStartPos�� VRDelta�� �ִٸ� ���������ʿ�

        playerRB.useGravity = false;
    }
    public override void Interaction(Vector3 updatedVec)
    {
        if (playerTR == null || playerRB == null)
        {
            return;
        }
        else if (playerTR != null && playerRB != null)
        {
            playerTR.position += updatedVec*-1;
            //TODO : ����� ���� �ڵ��̹Ƿ� ��Ʈ�ѷ� ���� �� ��Ʈ�ѷ� Delta���� ���ٸ�playerTR.position = grabStartPos-(Vector3.up*updatedVec.y);
            //�ִٸ� �׳� �״�� ����ɵ�?..
        }
    }
    public override void outIt()
    {
        playerRB.useGravity = true;
        playerTR = null;
        playerRB = null;
        grabStartPos = 0;
    }
}
public enum InteractionActions
{
    none,climbing,removeStatic,grabItem
}
[System.Serializable]
public class InteractionDetailPosition
{
    public Vector3 size = new Vector3(1,1,1);
    //heoyoon : 128,128,128 == �׸����� ���߾�
    public byte x = 128;
    public byte y = 128;
    public byte z = 128;
}
