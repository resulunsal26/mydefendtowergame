using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerhealth : MonoBehaviour
{
    [SerializeField] private  int health = 10;
    [SerializeField] private int healthdegrees = 1;
    [SerializeField] Text healthtext;
    [SerializeField] AudioClip playerdamagesound;
    void Start()
    {
        healthtext.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        health -= healthdegrees;
        GetComponent<AudioSource>().PlayOneShot(playerdamagesound);
        healthtext.text = health.ToString();
    }


}
