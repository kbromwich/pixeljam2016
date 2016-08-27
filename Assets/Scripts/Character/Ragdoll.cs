using UnityEngine;
using System.Collections;

public class Ragdoll : MonoBehaviour {

    public GameObject RagdollToSpawn;
    public float TimeSinceRagdoll;

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
            ragRb.velocity = ragRb.mass * (body.velocity / body.mass) * 30;

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
        Destroy(ragdoll);
    }
}
