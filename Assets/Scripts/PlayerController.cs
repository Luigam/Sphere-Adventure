using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    [SerializeField] private float speed;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        SphereMovement();
    }
    void SphereMovement()
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
}
