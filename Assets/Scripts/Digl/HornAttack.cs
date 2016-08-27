using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Attack))]
public class HornAttack : MonoBehaviour {

    public GameObject Emitter;
    public Health HealthToAvoid;

    void Awake()
    {
        Emitter = GameObject.Instantiate(Resources.Load<GameObject>("Sparks"));
    }

	private void OnCollisionEnter(Collision c){
        HealthHitbox health = c.gameObject.GetComponent<HealthHitbox>();

		if (health && health != HealthToAvoid) {
            Instantiate(Emitter, c.transform.position, c.transform.rotation);
            Attack attackComp = GetComponent<Attack>();
            attackComp.MakeAttack(health.health);
		}
	}
}
