using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody rb;
    private Vector2 inputVector;

    [Header("References")]
    [SerializeField] private Transform cameraTransform; // assign Main Camera here

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
        rb.useGravity = true; // make sure gravity is on
        rb.isKinematic = false;
    }

    private void HandleMoveInput(Vector2 input)
    {
        inputVector = input;
    }

    private void FixedUpdate()
    {
        if (cameraTransform == null) return;

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 move = camForward * inputVector.y + camRight * inputVector.x;
        move.Normalize(); // prevent diagonal speed boost

        // Keep existing Y velocity (gravity)
        Vector3 targetVelocity = move * moveSpeed;
        Vector3 currentVelocity = rb.velocity;
        targetVelocity.y = currentVelocity.y;

        rb.velocity = targetVelocity;

        // Rotate player to face movement direction
        if (move.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

}
