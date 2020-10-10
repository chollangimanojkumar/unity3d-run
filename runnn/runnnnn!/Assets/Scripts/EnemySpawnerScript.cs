using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public Transform[] spawnPosition;
        public GameObject enemy;
    float timeBtwSpawn = 30f;
    // Start is called before the first frame update

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {


            //instantiate (name,position,rotation)
            //Instantiate(enemy, spawnPosition[1].position); Quaternion.identity);  //quaternion,identity means no change
            Instantiate(enemy, spawnPosition[Random.Range(0,spawnPosition.Length)].position, Quaternion.identity);

            timeBtwSpawn = 60f;
        }
        else
        {
            timeBtwSpawn--;
        }
    }
}
