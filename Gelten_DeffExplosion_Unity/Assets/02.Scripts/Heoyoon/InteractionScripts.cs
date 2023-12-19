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
    public void InteractionCon(Vector3 playerPos,Vector3 updatedVec)
    {

        if (isOverlab(playerPos))
        {
            Interaction(updatedVec);
        }
    }
    public abstract void Interaction(Vector3 updatedVec);
    //누르고 있는동안 작동
    public abstract void outIt();
    //키를 땔때 작동
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
        //TODO : grabStartPos는 VRDelta가 있다면 변수제거필요

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
            //TODO : 디버그 전용 코드이므로 컨트롤러 연결 시 컨트롤러 Delta값이 없다면playerTR.position = grabStartPos-(Vector3.up*updatedVec.y);
            //있다면 그냥 그대로 쓰면될듯?..
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
    //heoyoon : 128,128,128 == 그리드의 정중앙
    public byte x = 128;
    public byte y = 128;
    public byte z = 128;
}
