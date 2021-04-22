using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 public class Node : MonoBehaviour
{
    public int nodeId; //position the route
    public Text numberText;
    public Node connectedNode; // ladderorsneak

 public void SetNodeId(int _nodeId)
    {
        nodeId = _nodeId;
        if(numberText != null)
        {
            numberText.text = nodeId.ToString();
        }
    }
    void OnDrawGizmos()
    {
        if(connectedNode != null)
        {
            Color col = Color.white;
            col = (connectedNode.nodeId > nodeId) ? Color.blue : Color.red;

            Debug.DrawLine(transform.position, connectedNode.transform.position, col);
        }
    }
}