using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    public HashSet<Vector3Int> interactionGrid = new HashSet<Vector3Int>();
    private Vector3Int AddInteractions { set { interactionGrid.Add(value); } }

    private Dictionary<Vector3Int,InteractionScripts> interactionObjects =  new Dictionary<Vector3Int,InteractionScripts>();
    public Dictionary<Vector3Int, InteractionScripts> Interaction { get { return interactionObjects; } }
    //heoyoon : 씬 전환시 위에있는 모든 딕셔너리와 해쉬셋 초기화 필요
    public void GridInteractionSetting(InteractionActions actions,Vector3Int pos, InteractionDetailPosition tempDetail)
    {
        if (!interactionGrid.Contains(pos))
        {
            Debug.Log("등록 되었습니다 : "+actions.ToString() + pos);
            switch (actions)
            {
                case InteractionActions.none:

                    break;
                case InteractionActions.climbing:
                    AddInteractions = pos;
                    interactionObjects.Add(pos, new Climbing {detail = new InteractionDetailPosition {size = tempDetail.size, x= tempDetail.y,y= tempDetail.y,z= tempDetail.z, } });
                    break;
                case InteractionActions.removeStatic:
                    AddInteractions = pos;
                    break;
                case InteractionActions.grabItem:
                    AddInteractions = pos;
                    break; ;
            }
        }
        else
        {
            Debug.LogError("그리드 중복등록, 오류 확인필요 오류 좌표 : " + pos);
        }
    }
}
