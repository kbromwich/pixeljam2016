using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SphereCollider))]
public class Poop : MonoBehaviour {

	private float countdown = 3f;

	private float endRadius = 20f;

	private float radiusExpansionRate = 80f;

	private float explosionForce = 10000f;

	private SphereCollider col;

	// Use this for initialization
	void Start () {
		col = GetComponent<SphereCollider> ();
		StartCoroutine (ExplosionCountdown ());
	}

	private IEnumerator ExplosionCountdown(){
		yield return new WaitForSeconds (countdown);
		Explode ();
	}

	private void Explode(){
		StartCoroutine (RunExplsoion ());
	}

	private IEnumerator RunExplsoion(){
		float radius = 0f;
		while (radius < endRadius) {
			radius += radiusExpansionRate * Time.deltaTime;
			col.radius = radius;
			yield return null;
		}
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider c){
		Ragdoll ragdoll = c.GetComponent<Ragdoll> ();
		if (ragdoll) {
			ragdoll.ActiveRagdoll ();
		}

		Rigidbody body = c.GetComponent<Rigidbody> ();
		if (body) {
			body.AddExplosionForce (explosionForce, transform.position, endRadius);		
		}
	}
}
