using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    Health health;
    bool HasDied = false;

	// Use this for initialization
	void Start () {
        health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {

	    if(!HasDied && health != null && health.health < 0)
        {
            HasDied = true;
            //TODO implement deaths something?
            Destroy(gameObject);
        }
	}
}
