using UnityEngine;
using System.Collections;

public class DismemberRagdoll : MonoBehaviour {

	public void DismemberAfterCountdown(float time){
		StartCoroutine(RunDismemberCountdown(time));
	}

	private IEnumerator RunDismemberCountdown(float time){
		yield return new WaitForSeconds (time);
		if (gameObject.activeSelf) {
			Joint[] allJoints = GetComponentsInChildren<Joint> ();
			for (int k = 0; k < allJoints.Length; k++) {
				Destroy (allJoints [k]);
			}
		}
	}
}
