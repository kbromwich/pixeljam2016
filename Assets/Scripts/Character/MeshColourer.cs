using UnityEngine;
using System.Collections;

public class MeshColourer : MonoBehaviour {
	
	public Renderer[] meshesToColour;

	public Color color;

	public void SetMaterialColour(Color color)
	{
		this.color = color;
		foreach (Renderer smr in meshesToColour) {
			smr.material.color = color;
		}
	}
}
