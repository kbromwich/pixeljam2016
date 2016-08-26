using UnityEngine;
using System.Collections;

public class AISpawner : MonoBehaviour {

    public GameObject ItemToSpawn;
    public int SpawnCount = 200;
    public float SpawnTime = 10.0f;

    float TimeSinceLastSpawn = 0.0f;
    float TimeBetweenSpawns = 0.0f;
    int SpawnsLeft = 0;

    void Start()
    {
        TimeBetweenSpawns = SpawnTime / SpawnCount;
        SpawnsLeft = SpawnCount;
    }


	// Update is called once per frame
	void Update () {
        if(SpawnsLeft > 0)
        {
            TimeSinceLastSpawn += Time.deltaTime;

            if (TimeSinceLastSpawn > TimeBetweenSpawns)
            {
                //Spawn shit
                GameObject spawnedGameObject = Instantiate<GameObject>(ItemToSpawn);
                spawnedGameObject.transform.position = transform.position;
                TimeSinceLastSpawn = 0;
                --SpawnsLeft;
            }
        }
    }
       
}
