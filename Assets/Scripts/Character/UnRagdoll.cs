using UnityEngine;
using System.Collections;

public class UnRagdoll : MonoBehaviour {

    public string inputCommand = "";
    public Ragdoll reactivate = null;
    public SkinnedMeshRenderer ChestSkinnerMeshRenderer;

    public GameObject WhereToSpawn;
    public GameObject Horn;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inputCommand != "" && Input.GetButtonDown(inputCommand))
        {
            if (reactivate)
            {
                reactivate.Reactivate(gameObject, WhereToSpawn);
            }
        }
    }
}
