using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float AttackReach = 2.0f;

	// Update is called once per frame
	void Update () {

        //Player has attacked
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack attack = GetComponent<Attack>();

            if(attack)
            {
                //Check if player is looking at someone with health.
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, AttackReach))
                {
                    //Damage the health
                    Health health = hit.collider.GetComponent<Health>();
                    if(health != null)
                    {
                        attack.MakeAttack(health);
                        Debug.DrawRay(transform.position, transform.position + transform.forward * AttackReach);

                    }
                   
                }
                    
            }
            else
            {
                print("Player doesn't have an attack class");
            }
        }
	}
}
