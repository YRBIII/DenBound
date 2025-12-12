using UnityEngine;

// Handles physics-based player movement using Rigidbody and input events
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector2 inputVector;

    // Subscribes to movement input events
    private void OnEnable()
    {
        InputManager.OnMove += HandleMoveInput;
    }

    // Unsubscribes from movement input events
    private void OnDisable()
    {
        InputManager.OnMove -= HandleMoveInput;
    }

    // Initializes Rigidbody settings for player movement
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.useGravity = true;
    }

    // Receives and stores movement input
    private void HandleMoveInput(Vector2 input)
    {
        inputVector = input;
    }

    // Applies movement at a fixed timestep
    private void FixedUpdate()
    {
        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 move = forward * inputVector.y + right * inputVector.x;
        move.Normalize();

        Vector3 targetVel = move * moveSpeed;
        targetVel.y = rb.velocity.y;

        rb.velocity = targetVel;
    }
}
