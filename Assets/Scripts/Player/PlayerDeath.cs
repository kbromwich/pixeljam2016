using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Health))]
public class PlayerDeath : MonoBehaviour {

	public void Kill(){


        Ragdoll ragdoll = GetComponent<Ragdoll>();

		GameObject ragdollObject = ragdoll.RagdollParent;
		if (ragdollObject != null) {
			ragdollObject.GetComponent<MeshColourer> ().SetMaterialColour (Color.black);
		}
		GetComponent<MeshColourer> ().SetMaterialColour (Color.black);

        if(!ragdoll.RagdollIsActive)
        {
            ragdoll.ActiveRagdoll();

		}

		DismemberRagdoll dismember = ragdoll.RagdollParent.GetComponentInChildren<DismemberRagdoll> ();
		dismember.DismemberAfterCountdown (0.5f);

        ragdoll.UnRagdoll.SpawnedBy = null;

		GameController controller = FindObjectOfType<GameController>();
		controller.KillPlayer(GetComponent<Player>());
		Destroy(gameObject);
	}
}
