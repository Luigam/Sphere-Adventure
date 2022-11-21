using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Rigidbody playerRigidBody;

    [SerializeField] private float jumpForce;

    private void Start()
    {
        playerRigidBody = playerController.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Impulse();
        }
    }

    private void Impulse()
    {
        playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
