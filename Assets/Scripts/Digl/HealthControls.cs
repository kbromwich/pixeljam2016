using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class HealthControls : MonoBehaviour {

	private Health health;
	// Use this for initialization
	void Start () {
		health = GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U)) {
			health.TakeDamage (-10f);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			health.TakeDamage (10f);
		}
	}
}
