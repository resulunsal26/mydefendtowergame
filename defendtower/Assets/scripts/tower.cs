using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    [SerializeField] private Transform objectopan;
    [SerializeField] private float atackrange;
    [SerializeField] private ParticleSystem projectileparticle;
    Transform targetenemy;
    [HideInInspector]
    public waypoint basewapoint;
    private void Update()
    {
      settargetenemy();
        if(targetenemy)
        {
            objectopan.LookAt(targetenemy);
            fireatenemy();
        }
        else
        {
            shoot(false);
        }
    }
    private void settargetenemy()
    {
        var sceneenemies = FindObjectsOfType<enemydamage>();
        if(sceneenemies.Length==0)
        {
            return;
        }
        Transform closestenemy = sceneenemies[0].transform;
        foreach (var item in sceneenemies)
        {
            closestenemy = Getclosest(closestenemy,item.transform);
        }
        targetenemy = closestenemy;
    }
    private Transform Getclosest(Transform closestenemy,Transform _transform)
    {
        var distoclosestenemy = Vector3.Distance( transform.position, closestenemy.position);
        var distotransform = Vector3.Distance(transform.position, _transform.position);
        if(distoclosestenemy<distotransform)
        {
            return closestenemy;
        }
        return _transform;
    }
    private void fireatenemy()
    {
        float distancetoenemy = Vector3.Distance(targetenemy.transform.position, transform.position);
        if(distancetoenemy<=atackrange)
        {
            shoot(true);
        }
        else
        {
            shoot(false);
        }
    }
    private void shoot(bool v)
    {
        var emmisionmodule = projectileparticle.emission;
        emmisionmodule.enabled = v;
    }
}
