using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour
{
    public Transform[] spawnPosition;
    public GameObject transulate;
    float timeBtwSpawn = 80f;
    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {


           Instantiate(transulate, spawnPosition[Random.Range(0, spawnPosition.Length)].position, transform.rotation);

            timeBtwSpawn = 80f;
        }
        else
        {
            timeBtwSpawn--;
        }
    }
}

