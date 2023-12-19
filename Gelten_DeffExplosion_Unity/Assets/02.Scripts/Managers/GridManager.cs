using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    public HashSet<Vector3Int> interactionGrid = new HashSet<Vector3Int>();
    private Vector3Int AddInteractions { set { interactionGrid.Add(value); } }

    private Dictionary<Vector3Int,InteractionScripts> interactionObjects =  new Dictionary<Vector3Int,InteractionScripts>();
    public Dictionary<Vector3Int, InteractionScripts> Interaction { get { return interactionObjects; } }
    //heoyoon : �� ��ȯ�� �����ִ� ��� ��ųʸ��� �ؽ��� �ʱ�ȭ �ʿ�
    public void GridInteractionSetting(InteractionActions actions,Vector3Int pos, InteractionDetailPosition tempDetail)
    {
        if (!interactionGrid.Contains(pos))
        {
            Debug.Log("��� �Ǿ����ϴ� : "+actions.ToString() + pos);
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
            Debug.LogError("�׸��� �ߺ����, ���� Ȯ���ʿ� ���� ��ǥ : " + pos);
        }
    }
}
