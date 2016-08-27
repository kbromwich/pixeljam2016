using UnityEngine;
using System.Collections;

public class RotatePassively : MonoBehaviour {

	public Vector3 passiveRotation;

	void FixedUpdate(){
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles + passiveRotation);
	}
}
