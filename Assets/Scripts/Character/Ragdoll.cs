using UnityEngine;
using System.Collections;

public class Ragdoll : MonoBehaviour {

    public GameObject RagdollToSpawn;
    public float TimeSinceRagdoll;
    public GameObject StandardCharacter;

    public PlayerMovementInput input;

    public string Controller;
    GameObject SpawnedRagdoll;

    bool RagdollIsActive = false;
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown(Controller + "Fire1"))
        {
            if(RagdollIsActive)
            {
                Destroy(SpawnedRagdoll);
                StandardCharacter.SetActive(true);
                RagdollIsActive = false;
                if (input != null)
                {
                    input.enabled = true;
                }
            }
            else
            {
                SpawnedRagdoll = Instantiate(RagdollToSpawn);
                SpawnedRagdoll.transform.position = StandardCharacter.transform.position;
                SpawnedRagdoll.transform.rotation = StandardCharacter.transform.rotation;
                SpawnedRagdoll.transform.localScale = StandardCharacter.transform.localScale;
                //SpawnedRagdoll.transform.parent = StandardCharacter.transform.parent;
                StandardCharacter.SetActive(false);
                if(input != null)
                {
                    input.enabled = false;
                }
                RagdollIsActive = true;
            }
           
            
        }
	}
}
