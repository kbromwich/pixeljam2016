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
        BestCharacter character = other.GetComponent<BestCharacter>();
        if (character != null)
        {
            target.TargetTransform = character.transform;
        }
    }
}
