using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {


    Rigidbody RigidB;
    Transform TargetTransform;

    public float WalkSpeed = 1.0f;
    public float MaxVelocityMag = 200.0f;

    // Use this for initialization
    void Start ()
    {
        RigidB = GetComponent<Rigidbody>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void FixedUpdate()
    {
        if(RigidB != null && RigidB.velocity.magnitude < MaxVelocityMag)
        {
            if(TargetTransform != null)
            {
                Vector3 movement = TargetTransform.position - transform.position;
                Vector3 NormalMovement =  movement.normalized;
                //print(NormalMovement);
                float VerticalSpeed = NormalMovement.z * WalkSpeed * Time.deltaTime * RigidB.mass;
                float HorizontalSpeed = NormalMovement.x * WalkSpeed * Time.deltaTime * RigidB.mass;
                RigidB.AddForce(new Vector3(VerticalSpeed, 0, HorizontalSpeed));
                //print(RigidB.velocity.magnitude);
            }
      
        }
    }


    void OnTriggerEnter(Collider other)
    {
        BestCharacter character = other.GetComponent<BestCharacter>(); 
        if (character != null)
        {
            TargetTransform = character.transform;
            print("Got Him");
        }
    }
}
