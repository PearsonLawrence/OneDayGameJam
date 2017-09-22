using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Enemies;
    public int[] count;
    public float timer;
    private float startTime;
    public float delay;
    private float startDelay;
    public int size;
    public int zRange;
    public int xRange;
    bool Spawn = false;
	// Use this for initialization
	void Start () {
        startTime = timer;
        startDelay = delay;
	}
	

    void SpawnEnemy()
    {
        int idx = Random.Range(0, size -1);
        var SpawnBaby = Enemies[idx];
        for(int i = 0; i < count[idx]; i++)
        {
            int x = Random.Range(0, xRange);
            int z = Random.Range(0, zRange);
            SpawnBaby.transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
            Instantiate(SpawnBaby);
            
        }
        count[idx]++;
        Spawn = false;
    }

	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Spawn = true;
            timer = startTime;
           
        }

        if(Spawn == true)
        {
            delay -= Time.deltaTime;
            if(delay <= 0 )
            {
                SpawnEnemy();
                delay = startDelay;
            }
           
        }
	}
}
