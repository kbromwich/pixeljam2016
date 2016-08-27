using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 69.0f;
	public float maxHealth = 69f;

	public delegate void HealthChangedDelegate(float normHealthValue);
	public event HealthChangedDelegate HealthChangedEvent;

    public virtual void TakeDamage(float damage)
	{
        print("Hit! Damage dealt: " + damage);
        ChangeHealth(-Mathf.Abs(damage));

    }

	public virtual void ChangeHealth(float amount)
	{
        //print("Health changed to " + amount);
		health += amount;
		if (HealthChangedEvent != null) {
			HealthChangedEvent (health / maxHealth);
		}
		if(health < 0f)
		{
			KillCharacter();
		}
	}

	protected virtual void KillCharacter()
    {
		GetComponent<PlayerDeath> ().Kill ();
    }

}
