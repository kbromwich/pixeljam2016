﻿using UnityEngine;
using System.Collections;

public class MeshColourer : MonoBehaviour {
	
	public Renderer[] meshesToColour;

	public Color color;

	public void SetMaterialColour(Color color)
	{
		this.color = color;
		HasGlowTexture[] hgt = GetComponentsInChildren<HasGlowTexture> ();
		Renderer r;
		foreach (HasGlowTexture h in hgt) {
			r = h.GetComponent<Renderer> ();
			r.material.SetColor ("_MKGlowColor", color);
			r.material.SetColor ("_MKGlowTexColor", color);
		}
		foreach (Renderer rend in meshesToColour) {
			rend.material.color = color;
		}
		Xft.XWeaponTrail[] trails = GetComponentsInChildren<Xft.XWeaponTrail> ();
		foreach (Xft.XWeaponTrail x in trails) {
			x.MyColor = color;
		}
	}
}
