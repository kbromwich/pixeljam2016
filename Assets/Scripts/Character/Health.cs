using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 69.0f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            KillCharacter();
        }
    }

    void KillCharacter()
    {

    }

}
