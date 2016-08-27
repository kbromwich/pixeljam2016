using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 69.0f;
	public float maxHealth = 69f;

	public delegate void HealthChangedDelegate(float normHealthValue);
	public event HealthChangedDelegate HealthChangedEvent;

    public void TakeDamage(float damage)
	{
		ChangeHealth(-damage);
    }

	private void ChangeHealth(float amount)
	{
		health += amount;
		if(HealthChangedEvent != null)
			HealthChangedEvent (health/maxHealth);
		if(health < 0f)
		{
			KillCharacter();
		}
	}

    void KillCharacter()
    {
		// rip
    }

}
