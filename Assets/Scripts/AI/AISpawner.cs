using UnityEngine;
using System.Collections;

public class AISpawner : MonoBehaviour {

    public GameObject ItemToSpawn;
    public int SpawnCount = 200;
    public float SpawnTime = 10.0f;

    public Vector3 StartVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    public bool RandomVelocity = false;
    public Vector3 RandomVelocityRange = new Vector3(0.0f, 0.0f, 0.0f);

    public float SpawnRange = 10.0f;

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
                
                spawnedGameObject.transform.position = transform.position + Random.onUnitSphere * SpawnRange;
                TimeSinceLastSpawn = 0;
                --SpawnsLeft;

                Rigidbody rigid = spawnedGameObject.GetComponent<Rigidbody>();
                if(rigid)
                {

                    if(RandomVelocity)
                    {
                        float xVel = Random.Range(0, RandomVelocityRange.x);
                        float yVel = Random.Range(0, RandomVelocityRange.y);
                        float zVel = Random.Range(0, RandomVelocityRange.z);

                        rigid.velocity = new Vector3(xVel, yVel, zVel);
                    }
                    else
                    {
                        rigid.velocity = StartVelocity;
                    }
                    
                }
            }
        }
    }
       
}
