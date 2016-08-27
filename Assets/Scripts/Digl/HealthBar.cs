using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	private Health health;
	public RectTransform healthRect;

	public void SetHealthToFollow(Health h){
		health = h;
		health.HealthChangedEvent += HealthChanged;
	}

	void OnDisable(){
		health.HealthChangedEvent -= HealthChanged;
	}

	private void HealthChanged(float normHealthValue){
		Debug.Log ("Health changed! " + normHealthValue);
	}
}
