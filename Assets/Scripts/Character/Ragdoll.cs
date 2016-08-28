using UnityEngine;
using System.Collections;
using System;

public class Ragdoll : MonoBehaviour {

    public GameObject RagdollToSpawn;
    public float TimeSinceRagdoll;
    public float VelocityMultiplier = 30.0f;

    [HideInInspector]
    public bool RagdollIsActive = false;

    Rigidbody body;

    public string Controller;



    [HideInInspector]
    public GameObject RagdollParent;
    [HideInInspector]
    public GameObject RagdollBody;
    [HideInInspector]
    public UnRagdoll UnRagdoll;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(Controller + "Fire1"))
        {
            ActiveRagdoll();
        }
	}
           
    public void ActiveRagdoll()
    {
        RagdollParent = Instantiate(RagdollToSpawn);

        // We pass the reference to our own health on the the ragdoll. Its collider's events will be pushed onto ours, this way.
        HealthReference ragdollHealth = RagdollParent.GetComponent<HealthReference>();
        ragdollHealth.actualHealth = GetComponent<Health>();
        RagdollParent.transform.position = gameObject.transform.position;
        RagdollParent.transform.rotation = gameObject.transform.rotation;

        UnRagdoll = RagdollParent.GetComponent<UnRagdoll>();
        RagdollBody = UnRagdoll.WhereToSpawn;
        Rigidbody ragRb = UnRagdoll.WhereToSpawn.GetComponent<Rigidbody>();
        ragRb.velocity = ragRb.mass * (body.velocity / body.mass) * VelocityMultiplier;

        Rigidbody HornRB = UnRagdoll.Horn.GetComponent<Rigidbody>();
        HornRB.AddForce(ragRb.transform.forward * -6000.0f);

		MeshColourer colourer = RagdollParent.GetComponent<MeshColourer> ();
		colourer.SetMaterialColour (gameObject.GetComponent<MeshColourer> ().color);

//		unrag.ChestSkinnerMeshRenderer.material.color = GetComponent<MeshColourer>().color;
        //ragRb.AddTorque(ragRb.transform.forward * 300000000.0f);
        //ragRb.AddForce(ragRb.transform.forward * 10000000.0f);


        //Health 
		Health thisHealth = GetComponent<Health>();
        Health ragHealth = RagdollParent.GetComponent<Health>();
		ragHealth.health = thisHealth.health;

		HornAttack hornAttack = RagdollParent.GetComponentInChildren<HornAttack> ();
		hornAttack.HealthToAvoid = thisHealth;


        UnRagdoll.SpawnedBy = this;
        UnRagdoll.InputCommand = Controller + "Fire1";
        gameObject.SetActive(false);
        RagdollIsActive = true;
    }

    public void UpdatePositionToRagdoll(GameObject moveto)
    {
        gameObject.transform.position = moveto.transform.position;
        Vector3 velocity = moveto.GetComponent<Rigidbody>().velocity;
        body.velocity = velocity;
    }

    public void Reactivate()
    {
        gameObject.SetActive(true);

        //Health
//        Health health = ragdoll.GetComponent<Health>();
//        GetComponent<Health>().ChangeHealth(health.health);

        Destroy(RagdollParent);
        RagdollParent = null;
        RagdollBody = null;
        UnRagdoll = null;
        RagdollIsActive = false;
    }

}