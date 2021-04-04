using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerfactory : MonoBehaviour
{
    [SerializeField] int towerlimit = 4;
    [SerializeField] tower towerprefab;
    [SerializeField] Transform towerparenttransform;
    Queue<tower> towerqueue = new Queue<tower>();
    public void addtower(waypoint basewaypoint)
    {
        int numtowers = towerqueue.Count;
        if (numtowers < towerlimit)
        {
            Instantiatenewtower(basewaypoint);
        }

        else
        {
            moveexistingtower(basewaypoint);
        }

    }
    public void Instantiatenewtower( waypoint basewaypoint)
    {
        var newtower = Instantiate(towerprefab, basewaypoint.transform.position, Quaternion.identity);
        newtower.transform.parent = towerparenttransform;
        basewaypoint.isplaceable = false;
        newtower.basewapoint = basewaypoint;
        newtower.basewapoint.isplaceable = false;
        towerqueue.Enqueue(newtower);
    }
    public void moveexistingtower(waypoint newbasewaypoint)
    {

        var oldtower = towerqueue.Dequeue();
        oldtower.basewapoint.isplaceable = true ;
        newbasewaypoint.isplaceable = false;
        oldtower.basewapoint = newbasewaypoint;
        oldtower.transform.position = newbasewaypoint.transform.position;
        towerqueue.Enqueue(oldtower);

    }
}
