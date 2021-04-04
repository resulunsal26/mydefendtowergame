using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public bool isplaceable=true;
    const int gridsize = 10;
    towerfactory towerfactory;
    private void Awake()
    {
        towerfactory = Object.FindObjectOfType<towerfactory>();
    }
    public int  getgridsize()
    {
        return gridsize ;
    }
    public Vector2Int getgridpos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridsize), Mathf.RoundToInt(transform.position.z / gridsize));
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isplaceable)
            {
                towerfactory.addtower(this);
            }
            else
            {
                Debug.Log("dsadas");
            }
        }
    }
}
