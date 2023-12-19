using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float grapStartPosition;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] InteractionScripts lastInteraction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxisRaw("Vertical") * moveSpeed);
        if (Input.anyKey||Input.anyKeyDown)
        {
            InteractionTestKey();
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity += (Vector3.up * Time.deltaTime) * jumpForce;
            }
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            if (lastInteraction != null)
            {
                lastInteraction.outIt();
                lastInteraction = null;
            }
        }
    }

    private void InteractionTestKey()
    {
        Vector3Int tempVec = VectorToIntPos(transform.position);
        if (Managers.Grid.interactionGrid.Contains(tempVec))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                InteractionScriptRegistToPlayerCTRL(tempVec);
            }
            else if (Input.GetKey(KeyCode.F))
            {
                if (lastInteraction == null)
                {
                    InteractionScriptRegistToPlayerCTRL(tempVec);
                }
                else
                {
                    lastInteraction.InteractionCon(transform.position,new Vector3(0,Input.mouseScrollDelta.y*Time.deltaTime,0));
                    //TODO : Input.mouseScrollDelta.y대신 VRdelta값이 있으면 델타값을,없으면grabStartPosition에서 뺴줘야될듯
                }
            }
        }
        else if (!Managers.Grid.interactionGrid.Contains(tempVec) && lastInteraction!= null)
        {
            lastInteraction.outIt();
            lastInteraction = null;
            Debug.Log("스크립트 제거");
        }
    }
    public void InteractionScriptRegistToPlayerCTRL(Vector3Int tempVec)
    {
        lastInteraction = Managers.Grid.Interaction[tempVec];
        grapStartPosition = transform.position.y;
        lastInteraction.Init(this);
    }
    Vector3Int VectorToIntPos(Vector3 tempVec)
    {
        Vector3Int temVecInt = new Vector3Int(Mathf.RoundToInt(tempVec.x), Mathf.RoundToInt(tempVec.y), Mathf.RoundToInt(tempVec.z));
        return temVecInt;
    }
}
