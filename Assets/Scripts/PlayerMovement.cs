using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector2 inputVector;

    private void OnEnable()
    {
        InputManager.OnMove += HandleMoveInput;
    }

    private void OnDisable()
    {
        InputManager.OnMove -= HandleMoveInput;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.useGravity = true;
    }

    private void HandleMoveInput(Vector2 input)
    {
        inputVector = input;
    }

    private void FixedUpdate()
    {
        // Player forward
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
