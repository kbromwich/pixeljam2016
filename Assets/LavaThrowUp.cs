using UnityEngine;
using System.Collections;

public class LavaThrowUp : MonoBehaviour {

    public  Vector3 ThrowForce = Vector3.up * 1000;
    public float damage = 0.5f;

	void OnTriggerEnter(Collider collider)
    {
        print("InTriggerEnter");
        Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
        if(rb)
        {
            rb.AddForce(ThrowForce);
            print("throwing");
        }

        Health health = collider.gameObject.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(damage);
        }

        HealthHitbox healthHitbox = collider.gameObject.GetComponent<HealthHitbox>();
        if (healthHitbox)
        {
            healthHitbox.health.TakeDamage(damage);
        }
    }
}
