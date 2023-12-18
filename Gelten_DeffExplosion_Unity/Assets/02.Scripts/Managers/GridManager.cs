using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    HashSet<Vector3Int> interactionGrid = new HashSet<Vector3Int>();
    private Vector3Int AddInteractions { set { interactionGrid.Add(value); } }

    private Dictionary<Vector3Int,InteractionScripts> interactionObjects =  new Dictionary<Vector3Int,InteractionScripts>();
    public Dictionary<Vector3Int, InteractionScripts> Interaction { get { return interactionObjects; } }

    public void GridInteractionSetting(InteractionActions actions,Vector3Int pos)
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
                    interactionObjects.Add(pos, new Climbing());
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
