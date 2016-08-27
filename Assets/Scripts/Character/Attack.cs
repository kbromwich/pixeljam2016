using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public float damage = 15.0f;

    public float AttackDelay = 0.5f;
    public float NextAttackTime = 0.0f;

    public void MakeAttack(Health health)
    {
        if (NextAttackTime < Time.time)
        {
            health.TakeDamage(damage);
            NextAttackTime = Time.time + AttackDelay;
        }
    }
}
