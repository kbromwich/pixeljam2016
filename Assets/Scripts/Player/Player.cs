using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int Index;

	public Renderer[] playColourMeshes;

	// Your other calls are to Player.name, which is inherited from GameObject.name. Same diff.
//    public string Name;
    public Color color;

   public void SetMaterialColour(Color color)
    {
		foreach (Renderer smr in playColourMeshes) {
			smr.material.color = color;
		}
    }
}
