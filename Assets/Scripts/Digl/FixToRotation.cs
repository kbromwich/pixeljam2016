using UnityEngine;
using System.Collections;

public class FixToRotation : MonoBehaviour {

	private Quaternion forcedRotation;

	public float xRotation;
	public float yRotation;
	public float zRotation;

	// Use this for initialization
	void Awake () {
		forcedRotation = Quaternion.Euler (xRotation, yRotation, zRotation);
	}

	void LateUpdate(){
		transform.rotation = forcedRotation;
	}
}
