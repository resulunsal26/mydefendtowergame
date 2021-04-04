using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyspawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] private float secondsbetweenspawns=2f;
    [SerializeField] GameObject enemyprefab;
    [SerializeField] Transform enemyparenttransform;
    [SerializeField] private Text spawnedenemies;
    [SerializeField] AudioClip spawnenemysfx;
    int score;

    void Start()
    {
        StartCoroutine(repeatedlyspawnenemies());
    }
    IEnumerator repeatedlyspawnenemies()
    {
        while(true)
        {
            addscore();
            GetComponent<AudioSource>().PlayOneShot(spawnenemysfx);
            var newenemy = Instantiate(enemyprefab, transform.position, Quaternion.identity);
            newenemy.transform.parent = enemyparenttransform;
            yield return new WaitForSeconds(secondsbetweenspawns);
        }
    }
    void addscore()
    {
        score++;
        spawnedenemies.text = score.ToString();
    }



}
