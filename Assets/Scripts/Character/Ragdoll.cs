using UnityEngine;
using System.Collections;

public class Ragdoll : MonoBehaviour {

    public GameObject RagdollToSpawn;
    public float TimeSinceRagdoll;
    public float VelocityMultiplier = 30.0f;

    Rigidbody body;

    public string Controller;
    GameObject SpawnedRagdoll;

    bool RagdollIsActive = false;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(Controller + "Fire1"))
        {
            SpawnedRagdoll = Instantiate(RagdollToSpawn);
            var unrag = SpawnedRagdoll.GetComponent<UnRagdoll>();
            SpawnedRagdoll.transform.position = gameObject.transform.position;
            SpawnedRagdoll.transform.rotation = gameObject.transform.rotation;

            Rigidbody ragRb = unrag.WhereToSpawn.GetComponent<Rigidbody>();
            ragRb.velocity = ragRb.mass * (body.velocity / body.mass) * VelocityMultiplier;

            Rigidbody HornRB = unrag.Horn.GetComponent<Rigidbody>();
            HornRB.AddForce(ragRb.transform.forward * -6000.0f);
            //ragRb.AddTorque(ragRb.transform.forward * 300000000.0f);
            //ragRb.AddForce(ragRb.transform.forward * 10000000.0f);

            //Health 
            Health ragHealth = SpawnedRagdoll.GetComponent<Health>();
            ragHealth.health = GetComponent<Health>().health;

            unrag.inputCommand = Controller + "Fire1";
            unrag.reactivate = this;
            gameObject.SetActive(false);
        }
	}

    public void Reactivate(GameObject ragdoll, GameObject moveto)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = moveto.transform.position;
        Vector3 velocity = moveto.GetComponent<Rigidbody>().velocity;
        body.velocity = velocity;

        //Health
        Health health = ragdoll.GetComponent<Health>();
        GetComponent<Health>().ChangeHealth(health.health);

        Destroy(ragdoll);
    }
}
