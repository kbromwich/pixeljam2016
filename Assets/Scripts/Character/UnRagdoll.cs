using UnityEngine;
using System.Collections;

public class UnRagdoll : MonoBehaviour {

    public string inputCommand = "";
    public Ragdoll reactivate = null;

    public GameObject WhereToSpawn;

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
