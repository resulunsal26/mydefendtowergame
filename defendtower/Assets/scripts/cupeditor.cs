using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(waypoint))]
[SelectionBase]
public class cupeditor : MonoBehaviour
{
    waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<waypoint>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        snaptogrid();
        updatelabel();
    }
    public void snaptogrid()
    {
        int gridsize = waypoint.getgridsize();
        transform.position = new Vector3(waypoint.getgridpos().x * gridsize, 0f, waypoint.getgridpos().y * gridsize);

    }
    public void updatelabel()
    {
        string labeltext = waypoint.getgridpos().x + "," + waypoint.getgridpos().y;
        gameObject.name = labeltext;
    }
}
