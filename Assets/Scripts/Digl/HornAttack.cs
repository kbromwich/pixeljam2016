using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Attack))]
public class HornAttack : MonoBehaviour {

    public GameObject Emitter;
    public Health HealthToAvoid;

    void Awake()
    {
        Emitter = Resources.Load<GameObject>("Sparks");
    }

	private void OnTriggerEnter(Collider c){
        HealthHitbox health = c.gameObject.GetComponent<HealthHitbox>();
//		print ("Collision");
		if (health && (health != HealthToAvoid)) {
//			print ("Horn Attack collision!");
            Instantiate(Emitter, c.transform.position, c.transform.rotation);
            Attack attackComp = GetComponent<Attack>();
            attackComp.MakeAttack(health.health);
		}
	}
}
