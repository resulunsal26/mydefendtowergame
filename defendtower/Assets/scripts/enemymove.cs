using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    [SerializeField] float movementperiod=.5f;
    [SerializeField] ParticleSystem goparticle;
    List<waypoint> paths= new List<waypoint>();
    waypoint[] waypoints;
    int tagcount;
    void Start()
    {
        waypoints = FindObjectsOfType<waypoint>();
        loadlocks();
        createpath();
        StartCoroutine(followpath(paths));
    }
    private void createpath()
    {
       
        for(int i=1;i<=tagcount;i++)
        {
            foreach (waypoint item in waypoints)
            {
                if (item.tag != "Untagged" && item.tag==i.ToString())
                {
                    item.isplaceable = false;
                    paths.Add(item);
                }
            }
        }
        
    }
    private void loadlocks()
    {
        tagcount = 0;
        
        foreach(waypoint item in waypoints)
        {
            if(item.tag!="Untagged")
            {
                tagcount++;
            }
        }
    }
    IEnumerator followpath(List<waypoint> paths)
    {
        foreach(var item in paths)
        {
            transform.position = item.transform.position;
            yield return new WaitForSeconds(movementperiod);
           
        }
        selfdestruct();
    }
    private void selfdestruct()
    {
        var vfx = Instantiate(goparticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
