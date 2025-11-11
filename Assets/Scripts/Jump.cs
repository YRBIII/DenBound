using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private string floorTag = "Floor";

    private bool isJumping = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        InputManager.OnJump += HandleJump;  // This uses InputManager jump event
    }

    private void OnDestroy()
    {
        InputManager.OnJump -= HandleJump; // Prevents memory leaks
    }

    private void HandleJump(float value)    // InputManager detects the Jump input
    {
        if (!isJumping && value > 0f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(floorTag))
        {
            isJumping = false;
        }
    }
}