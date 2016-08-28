using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	private Health health;
	public RectTransform healthRect;
	private float maxHealthLength = 50f;

	public void SetHealthToFollow(Health h){
		health = h;
		health.HealthChangedEvent += HealthChanged;
	}

	private void HealthChanged(float normHealthValue){
        if (healthRect.rect != null)
        {
            Rect r = healthRect.rect;
       
            r.width = normHealthValue * maxHealthLength;
            healthRect.sizeDelta = new Vector2(r.width, r.height);

        }

	}
}
