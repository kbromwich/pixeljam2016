using UnityEngine;
using System.Collections;

public class CharRotator : MonoBehaviour {

    Rigidbody RigidB;

    void Start()
    {
        RigidB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
	void Update ()
    {
        if (RigidB != null)
        {
            if(RigidB.velocity.z > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        //Debug.DrawRay(transform.position, transform.forward, Color.red, 10);
    }
}
