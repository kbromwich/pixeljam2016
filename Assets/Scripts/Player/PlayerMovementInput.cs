using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WalkPhysics))]
public class PlayerMovementInput : MonoBehaviour
{

    public string Controller = "k";
    WalkPhysics Walker;

    void Start()
    {
        Walker = GetComponent<WalkPhysics>();
    }

    void Update()
    {
        float VerticalSpeed = Input.GetAxis(Controller + "Vertical");
        float HorizontalSpeed = Input.GetAxis(Controller + "Horizontal");
        Walker.SetMovementInput(new Vector3(VerticalSpeed, 0.0f, HorizontalSpeed));
    }

}