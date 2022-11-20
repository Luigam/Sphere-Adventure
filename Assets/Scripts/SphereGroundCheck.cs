using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            playerController.SphereState = SphereState.IS_ON_GROUND;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            playerController.SphereState = SphereState.IS_IN_AIR;
        }
    }
}
