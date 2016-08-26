using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    float damage = 15.0f;

    float AttackDelay = 0.5f;
    float NextAttackTime = 0.0f;

    public void MakeAttack(Health health)
    {
        if (NextAttackTime < Time.time)
        {
            health.TakeDamage(damage);
            NextAttackTime = Time.time + AttackDelay;
        }
    }
}
