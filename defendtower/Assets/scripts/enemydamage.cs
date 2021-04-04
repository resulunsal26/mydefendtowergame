using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    [SerializeField] int hitpoints=10;
    [SerializeField] ParticleSystem hitparticleprefab;
    [SerializeField] ParticleSystem deathparticleprefab;
    [SerializeField] AudioClip enemyhitsfx, enemydeathsfx;
    AudioSource myaudiosource;

    void Start()
    {
        myaudiosource = GetComponent<AudioSource>();   
    }

    private void OnParticleCollision(GameObject other)
    {
        proceshit();
        if(hitpoints<=0)
        {
             killenemy();
            deathparticleprefab.Play();
        }
    }
    private void killenemy()
    {
        var vfx = Instantiate(deathparticleprefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        AudioSource.PlayClipAtPoint(enemydeathsfx, Camera.main.transform.position);
        Destroy(gameObject);
    }
    private void proceshit()
    {
        hitpoints--;
        hitparticleprefab.Play();
        myaudiosource.PlayOneShot(enemyhitsfx);
    }
    void Update()
    {
        
    }
}
