using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public float damage = 15.0f;

	public float AttackDelay = 0.5f;
	public float NextAttackTime = 0.0f;

	public Rigidbody bodyForVelocityDamage;


	private float velocityDamage = 50f;
	private float velocityMax = 30f;

	public void MakeAttack(Health health)
	{
		if (NextAttackTime < Time.time)
		{
			health.TakeDamage(damage + GetVelocityDamage());
			NextAttackTime = Time.time + AttackDelay;
		}
	}

	public float GetVelocityDamage(){
		if (bodyForVelocityDamage) {
			float ret = Mathf.Clamp (bodyForVelocityDamage.velocity.magnitude / velocityMax, 0f, velocityMax) * velocityDamage;
			print(ret+"bonus damage");
			return ret;
		} else {
			return 0f;
		}
	}
}
