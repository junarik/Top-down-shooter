using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrail : MonoBehaviour {

    public GameObject trail;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    private void Update()
    {
        if (Time.time > timeBtwSpawn) {
            Instantiate(trail, transform.position, Quaternion.identity);
            timeBtwSpawn = Time.time + startTimeBtwSpawn;
        }
    }
}
