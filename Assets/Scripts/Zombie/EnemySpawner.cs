using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float Period;
    public GameObject Enemy;
    private float TimeUnitlNextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        TimeUnitlNextSpawn = Random.Range(0, Period);
    }

    // Update is called once per frame
    void Update()
    {
        TimeUnitlNextSpawn -= Time.deltaTime;
        if (TimeUnitlNextSpawn <= 0.0f) {
            TimeUnitlNextSpawn = Period;
            Instantiate(Enemy, transform.position, transform.rotation);
        }
    }
}
