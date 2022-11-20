using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SphereState
{
    IS_ON_GROUND, IS_IN_AIR
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SphereState sphereState;
    public SphereState SphereState { get => sphereState; set => sphereState = value; }

    private Rigidbody playerRigidBody;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Jetpack jetpack;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        SphereState = SphereState.IS_IN_AIR;
    }

    void Update()
    {
        Movement();
        JetpackJump();
        Jump();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            playerRigidBody.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            playerRigidBody.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerRigidBody.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playerRigidBody.AddForce(Vector3.left * speed);
        }
    }

    private void Jump()
    {
        if (SphereState == SphereState.IS_ON_GROUND && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void JetpackJump()
    {
        if (SphereState == SphereState.IS_IN_AIR && Input.GetKey(KeyCode.Space))
        {
            playerRigidBody.AddForce(Vector3.up * jetpack.BoostStrength, ForceMode.Force);
        }
    }
}
