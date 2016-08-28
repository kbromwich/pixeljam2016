using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Health))]
public class PlayerDeath : MonoBehaviour {

	public void Kill(){


        Ragdoll ragdoll = GetComponent<Ragdoll>();

		GameObject ragdollObject = ragdoll.SpawnedRagdoll;
		if (ragdollObject != null) {
			ragdollObject.GetComponent<MeshColourer> ().SetMaterialColour (Color.black);
		}
		GetComponent<MeshColourer> ().SetMaterialColour (Color.black);

        if(!ragdoll.RagdollIsActive)
        {
            ragdoll.ActiveRagdoll();

		}

		DismemberRagdoll dismember = ragdoll.SpawnedRagdoll.GetComponentInChildren<DismemberRagdoll> ();
		dismember.DismemberAfterCountdown (0.5f);

		GameController controller = FindObjectOfType<GameController>();
		controller.KillPlayer(GetComponent<Player>());
		Destroy(gameObject);
	}
}
