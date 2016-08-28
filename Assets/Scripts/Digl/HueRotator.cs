using UnityEngine;
using System.Collections;

public class HueRotator : MonoBehaviour {

	Renderer renderer;
	public float rotationRate = 0.1f;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
