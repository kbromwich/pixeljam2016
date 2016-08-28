using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class WalkPhysics : MonoBehaviour, DIReceiver {

    Rigidbody RigidB;

    public float WalkSpeed = 1.0f;
    public float MaxVelocityMag = 200.0f;
    public float VelocityFalloff = 0.05f;

    Vector3 NormalizedInput = Vector3.zero;

     // Use this for initialization
     void Start()
    {
        RigidB = GetComponent<Rigidbody>();
    }

    public void ApplyDI(Vector3 input)
    {
        NormalizedInput = input.normalized;
    }

    void FixedUpdate()
    {
        RigidB.velocity -= new Vector3(RigidB.velocity.x * VelocityFalloff * Time.deltaTime, 0.0f, RigidB.velocity.z * VelocityFalloff * Time.deltaTime);

        if (RigidB.velocity.magnitude < MaxVelocityMag)
        {
            //Feature not bug. Run faster diag
            float VerticalSpeed = NormalizedInput.x * WalkSpeed * Time.deltaTime * RigidB.mass;
            float HorizontalSpeed = -NormalizedInput.z * WalkSpeed * Time.deltaTime * RigidB.mass;
			RigidB.AddForce(new Vector3(VerticalSpeed, 0, HorizontalSpeed), ForceMode.Impulse);
        }

        NormalizedInput = Vector3.zero;
    }
}
