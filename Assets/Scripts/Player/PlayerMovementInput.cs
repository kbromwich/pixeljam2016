using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WalkPhysics))]
public class PlayerMovementInput : MonoBehaviour
{

    public string Controller = "k";
    DIReceiver DIReceiver;

    void Start()
    {
        DIReceiver = GetComponent<WalkPhysics>();
    }

    void Update()
    {
        float VerticalSpeed = Input.GetAxis(Controller + "Vertical");
        float HorizontalSpeed = Input.GetAxis(Controller + "Horizontal");
        if (DIReceiver != null)
        {
            DIReceiver.ApplyDI(new Vector3(VerticalSpeed, 0.0f, HorizontalSpeed));
        }
    }

}