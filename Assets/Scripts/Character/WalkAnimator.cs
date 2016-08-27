using UnityEngine;
using System.Collections;

public class WalkAnimator : MonoBehaviour
{

    public Animator animator;
    public float StoppedWalkingSpeed = 1.0f;

    bool animatorStopped = false;
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.magnitude < StoppedWalkingSpeed)
        {
            animator.Stop();
            animatorStopped = true;
        }
        else
        {
            if (animatorStopped)
            {
                animator.StartPlayback();
                animatorStopped = false;
            }
        }


    }
}
