using UnityEngine;
using System.Collections;

public class AIWalk : MonoBehaviour {


    Rigidbody RigidB;
    Target target;

    public float WalkSpeed = 1.0f;
    public float MaxVelocityMag = 200.0f;

    // Use this for initialization
    void Start ()
    {
        RigidB = GetComponent<Rigidbody>();
        target = GetComponent<Target>();
    }
	

    void FixedUpdate()
    {
        if(RigidB != null && RigidB.velocity.magnitude < MaxVelocityMag)
        {
            if(target != null && target.TargetTransform != null)
            {
                Vector3 movement = target.TargetTransform.position - transform.position;
                Vector3 NormalMovement =  movement.normalized;

                //print(NormalMovement);
                float VerticalSpeed = NormalMovement.x * WalkSpeed * Time.deltaTime * RigidB.mass;
                float HorizontalSpeed = NormalMovement.z * WalkSpeed * Time.deltaTime * RigidB.mass;

                RigidB.AddForce(new Vector3(VerticalSpeed, 0, HorizontalSpeed));
                //print(RigidB.velocity.magnitude);
            }
      
        }
    }
}
