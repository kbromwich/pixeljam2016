using UnityEngine;
using System.Collections;

public class HealthReference : Health {

	public Health actualHealth;

	public override void ChangeHealth (float amount)
	{
		actualHealth.ChangeHealth (amount);
	}

	public override void TakeDamage (float damage)
	{
		actualHealth.TakeDamage (damage);
	}

}
