using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControls : MonoBehaviour
{
    [SerializeField] private float velocity = 3f;
    //[SerializeField] private float gravity = 20.0f;
    private CharacterController characterController;
    private PlayerHealth playerHealth;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!playerHealth.isDead)
        {
            float horizontalInput = Input.GetAxis("Horizontal") * velocity;
            float verticalInput = Input.GetAxis("Vertical") * velocity;

            Vector3 forwardMovement = transform.forward * verticalInput;
            Vector3 rightMovement = transform.right * horizontalInput;

            characterController.SimpleMove(forwardMovement + rightMovement);
        }
    }
}
