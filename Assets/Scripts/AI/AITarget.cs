using UnityEngine;
using System.Collections;

public class AITarget : MonoBehaviour {

    Target target;

    void Start()
    {
        target = GetComponent<Target>();
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerMovementInput character = other.GetComponent<PlayerMovementInput>();
        if (character != null)
        {
            target.TargetTransform = character.transform;
        }
    }
}
