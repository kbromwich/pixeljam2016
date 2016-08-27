using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Health))]
public class PlayerDeath : MonoBehaviour {

	public void Kill(){


        Ragdoll ragdoll = GetComponent<Ragdoll>();

        if(!ragdoll.RagdollIsActive)
        {
            ragdoll.ActiveRagdoll();
        }

		GameController controller = FindObjectOfType<GameController>();
		controller.KillPlayer(GetComponent<Player>());
		Destroy(gameObject);
	}
}
