using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WalkPhysics))]
public class AIWalk : MonoBehaviour {

    WalkPhysics walker;
    Target target;
    // Use this for initialization
    void Start ()
    {
        target = GetComponent<Target>();
        walker = GetComponent<WalkPhysics>();
    }
	

    void FixedUpdate()
    {
        if(target != null && target.TargetTransform != null)
        {
            Vector3 movement = target.TargetTransform.position - transform.position;

            walker.SetMovementInput(new Vector3(movement.x, 0, movement.z));
            //print(RigidB.velocity.magnitude);
        }
    }
}
