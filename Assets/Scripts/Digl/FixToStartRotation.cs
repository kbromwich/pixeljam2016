using UnityEngine;
using System.Collections;

public class FixToStartRotation : MonoBehaviour {

	Quaternion startRotation;

	// Use this for initialization
	void Start () {
		startRotation = transform.rotation;
	}

	void LateUpdate(){
		transform.rotation = startRotation;
	}
}
