using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRuler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3Int gridStartPos;
    [SerializeField] Vector3Int gridEndPos;
    public float cellSize;
    public bool showGizmo;
    public HashSet<>

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        if (showGizmo)
        {
            Gizmos.DrawCube((gridStartPos + gridEndPos) / 2, Vec3Bound(gridStartPos,gridEndPos));
        }

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
