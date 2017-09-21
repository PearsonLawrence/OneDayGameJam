using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Enemies;
    public int[] count;
    public float timer;
    private float startTime;
    public int size;
	// Use this for initialization
	void Start () {
        startTime = timer;
	}
	

    void SpawnEnemy()
    {
        int idx = Random.Range(0, size -1);
        var SpawnBaby = Enemies[idx];
        for(int i = 0; i < count[idx]; i++)
        {
            int x = Random.Range(-10, 10);
            int z = Random.Range(-10, 10);
            SpawnBaby.transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
            Instantiate(SpawnBaby);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = startTime;
            SpawnEnemy();
        }
	}
}
