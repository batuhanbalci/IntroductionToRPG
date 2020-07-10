using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("PlayerVelocity", character.velocity.magnitude);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("ActiveSkill", false);

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("IsAttacking", true);
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("ActiveSkill", true);
        }
    }
}
