using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Route route;
    public List<Node> nodeList = new List<Node>();
    private Inventory inventory;

    int routePosition;
    int stoneId;
    float speed = 8f;
    int stepsToMove, doneSteps;

    bool isMoving;
   

   

    void Start()
    {
        foreach (Transform c in route.nodeList)
        {
            Node n = c.GetComponentInChildren<Node>();
            if (n != null)
            {
                nodeList.Add(n);
            }
        }
    }


    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }

        isMoving = true;
        while (stepsToMove > 0)
        {
            routePosition++;
            Vector3 nextPos = route.nodeList[routePosition].transform.position;

            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            stepsToMove--;
            doneSteps++;
        }
        yield return new WaitForSeconds(0.1f);
        //snake & ladder check
        if (nodeList[routePosition].connectedNode != null)
        {
            int conNodeId = nodeList[routePosition].connectedNode.nodeId;
            Vector3 nextPos = nodeList[routePosition].connectedNode.transform.position;

            while (MoveToNextNode(nextPos)) { yield return null; }
            doneSteps = conNodeId;
            routePosition = conNodeId;
        }

        //CHECK FOR A WIN
        if(doneSteps == nodeList.Count-1)
        {
            //REPORT TO GAMEMANAGER
            GameManager.instance.ReportWinner();
            yield break;
        }

        //UPDATE THE GAMEMANAGER
        GameManager.instance.state = GameManager.States.SWTCH_PLAYER;
        isMoving = false;

    }
    bool MoveToNextNode(Vector3 nextPos)
    {
        return nextPos != (transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime));

    }
    public void MakeTurn(int diceNumber)
    {
        stepsToMove = diceNumber;
        if (doneSteps + stepsToMove < route.nodeList.Count)
        {
            StartCoroutine(Move());
        }
        else
        {
            //print("the number is to high");
            //Update gamemamager
            GameManager.instance.state = GameManager.States.SWTCH_PLAYER;
        }
    }
}