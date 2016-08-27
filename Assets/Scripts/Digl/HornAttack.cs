using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Attack))]
public class HornAttack : MonoBehaviour {

	private void OnTriggerEnter(Collider c){
        HealthHitbox health = c.gameObject.GetComponent<HealthHitbox>();

		if (health) {
            Attack attackComp = GetComponent<Attack>();
            attackComp.MakeAttack(health.health);
		}
	}
}
