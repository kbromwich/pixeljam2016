using UnityEngine;
using System.Collections;

public class BestCharacter : MonoBehaviour {


    Rigidbody RigidB;

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

            //Feature not bug. Run faster diag
            float VerticalSpeed = Input.GetAxis("Vertical") * WalkSpeed * Time.deltaTime * RigidB.mass;
            float HorizontalSpeed = -Input.GetAxis("Horizontal") * WalkSpeed * Time.deltaTime * RigidB.mass;
            RigidB.AddForce(new Vector3(VerticalSpeed, 0, HorizontalSpeed));
        }
    }

}
