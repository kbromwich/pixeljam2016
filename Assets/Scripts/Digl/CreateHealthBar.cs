using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Health))]
public class CreateHealthBar : MonoBehaviour {

	void Start(){
		GameObject healthBarObject = GameObject.Instantiate(Resources.Load("Digl/HealthBar")) as GameObject;
		healthBarObject.transform.position = transform.position;
		healthBarObject.transform.rotation = transform.rotation;
		healthBarObject.transform.SetParent(transform);
		healthBarObject.GetComponent<HealthBar>().SetHealthToFollow(GetComponent<Health>());
		Destroy (this);
	}


}
