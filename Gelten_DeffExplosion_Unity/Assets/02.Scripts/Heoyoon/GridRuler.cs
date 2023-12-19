using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRuler : MonoBehaviour
{
    // Start is called before the first frame update
    public float cellSize;
    public bool showAreaGizmo;
    public InteractionRegisterClass[] interactionRegist;

    void Awake()
    {
        for (int i = 0; i < interactionRegist.Length; i++)
        {
            Managers.Grid.GridInteractionSetting(interactionRegist[i].action, interactionRegist[i].position,interactionRegist[i].details);
        }
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < interactionRegist.Length; i++)
        {
            Vector3 detailPos = byteTOFloatedVector(interactionRegist[i].position, interactionRegist[i].details.x, interactionRegist[i].details.y, interactionRegist[i].details.z);
            switch (interactionRegist[i].action)
            {
                case InteractionActions.none:
                    Gizmos.color = Color.red;
                    Gizmos.DrawCube(detailPos, interactionRegist[i].details.size);
                    break;
                case InteractionActions.climbing:
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawCube(detailPos, interactionRegist[i].details.size);
                    break;
                case InteractionActions.removeStatic:
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawCube(detailPos, interactionRegist[i].details.size);
                    break;
                case InteractionActions.grabItem:
                    Gizmos.color = Color.blue;
                    Gizmos.DrawCube(detailPos, interactionRegist[i].details.size);
                    break;
            }
        }            
        //TODO : 세팅된 타일맵 기즈모로 그려줘야함
    }
    Vector3 byteTOFloatedVector(Vector3Int IntPos,byte detailX, byte detailY, byte detailZ)
    {
        Vector3 ConvertedValue = new Vector3(detailX - 128, detailY - 128, detailZ - 128);
        ConvertedValue = (new Vector3(ConvertedValue.x/ 128f,ConvertedValue.y/ 128f, ConvertedValue.z/ 128f)) +IntPos;

        return ConvertedValue;
    }
}
[System.Serializable]
public class InteractionRegisterClass
{
    public Vector3Int position;
    public InteractionActions action;
    public InteractionDetailPosition details = new InteractionDetailPosition();
}
