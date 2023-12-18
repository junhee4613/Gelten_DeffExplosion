using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    HashSet<Vector3Int> interactionGrid = new HashSet<Vector3Int>();
    Vector3Int AddInteractions { set { interactionGrid.Add(value); } }

}
