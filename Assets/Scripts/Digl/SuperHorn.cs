using UnityEngine;
using System.Collections;

public class SuperHorn : MonoBehaviour {

	public Health ignoreHealth;
	public float damage = 100000f;

	private void OnCollisionEnter(Collision c){
		HealthHitbox hitbox = c.gameObject.GetComponent<HealthHitbox> ();

		if (hitbox) {
			if (hitbox.health != ignoreHealth)
				hitbox.health.TakeDamage (damage);
		}
	}
}
