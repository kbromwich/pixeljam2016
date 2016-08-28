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
        float verticalSpeed = Input.GetAxis(Controller + "Vertical");
        float horizontalSpeed = Input.GetAxis(Controller + "Horizontal");
        if (verticalSpeed != 0 || horizontalSpeed != 0)
        {
            print("input from " + Controller);
        }
        if (DIReceiver != null)
        {
            DIReceiver.ApplyDI(new Vector3(verticalSpeed, 0.0f, horizontalSpeed));
        }
    }

}