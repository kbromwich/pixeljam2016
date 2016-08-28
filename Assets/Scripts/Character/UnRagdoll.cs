using UnityEngine;
using System.Collections;

public class UnRagdoll : MonoBehaviour {

    public string InputCommand = "";
    public Ragdoll SpawnedBy = null;
    public SkinnedMeshRenderer ChestSkinnerMeshRenderer;

    public GameObject WhereToSpawn;
    public GameObject Horn;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SpawnedBy)
        {
            SpawnedBy.UpdatePositionToRagdoll(WhereToSpawn);
            if (InputCommand != "" && Input.GetButtonDown(InputCommand))
            {
                SpawnedBy.Reactivate();
            }
        }
    }
}
