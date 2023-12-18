using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRuler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3Int gridStartPos;
    [SerializeField] Vector3Int gridEndPos;
    public float cellSize;
    public bool showAreaGizmo;
    public InteractionRegisterClass[] interactionRegist; 

    void Awake()
    {
        for (int i = 0; i < interactionRegist.Length; i++)
        {
            Managers.Grid.GridInteractionSetting(interactionRegist[i].action, interactionRegist[i].position);
        }
    }
    private void OnDrawGizmos()
    {
        if (showAreaGizmo)
        {
            Gizmos.DrawCube((gridStartPos + gridEndPos) / 2, Vec3Bound(gridStartPos,gridEndPos));
        }
        //TODO : 세팅된 타일맵 기즈모로 그려줘야함

    }
    private Vector3Int Vec3Bound(Vector3Int tempVec, Vector3Int tempVec2)
    {
        int returnX = tempVec.x - tempVec2.x;
        int returnY = tempVec.y - tempVec2.y;
        int returnZ = tempVec.z - tempVec2.z;
        Vector3Int returnVector = new Vector3Int((int)Mathf.Sqrt(returnX * returnX), (int)Mathf.Sqrt(returnY * returnY), (int)Mathf.Sqrt(returnZ * returnZ));

        return returnVector;
    }
}
[System.Serializable]
public class InteractionRegisterClass
{
    public Vector3Int position;
    public InteractionActions action;
}
