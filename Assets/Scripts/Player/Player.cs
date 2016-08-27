using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int Index;

    public SkinnedMeshRenderer matRenderer;

    public string Name;
    public Color color;

   public void SetMaterialColour(Color color)
    {
        matRenderer.material.color = color;
    }
}
