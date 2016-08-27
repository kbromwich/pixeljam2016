using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Health))]
public class PlayerDeath : MonoBehaviour {

    Health health;
    bool HasDied = false;

	// Use this for initialization
	void Start () {
        health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {

	    if(!HasDied && health.health < 0)
        {
            HasDied = true;
            Ragdoll ragdoll = GetComponent<Ragdoll>();
            ragdoll.ActiveRagdoll();

            GameController controller = FindObjectOfType<GameController>();
            controller.KillPlayer(GetComponent<Player>());
            Destroy(gameObject);
        }
	}
}
