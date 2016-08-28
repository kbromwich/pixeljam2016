using UnityEngine;
using System.Collections;

public class Roller : MonoBehaviour {

    public string Pad = "1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        float x = Input.GetAxis(Pad + "Horizontal");
        float y = Input.GetAxis(Pad + "Vertical");
        var body = GetComponent<Rigidbody>();
        body.AddForce(x * 100, 0,  -y * 100);
    }
}
