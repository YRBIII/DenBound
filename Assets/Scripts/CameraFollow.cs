using UnityEngine;

// Handles third-person camera rotation based on mouse movement
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField][Range(0.1f, 2f)] private float mouseSpeed = 2f;
    [SerializeField] private float maxY = 60;
    [SerializeField] private float minY = -40;
    [SerializeField] private bool invertY;

    private Vector2 _cameraRotation = Vector2.zero;

    // Locks the cursor and starts listening for mouse movement input
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputManager.onMouseDelta += SetDirection;
    }

    // Rotates the camera and player based on mouse input
    private void SetDirection(Vector2 dir)
    {
        dir.y = invertY ? -dir.y : dir.y;

        _cameraRotation.x += dir.x * mouseSpeed;
        _cameraRotation.y += dir.y * mouseSpeed;

        player.localRotation = Quaternion.Euler(0f, _cameraRotation.x, 0f);
        transform.localRotation = Quaternion.Euler(
            Mathf.Clamp(_cameraRotation.y, minY, maxY),
            0f,
            0f
        );
    }

    // Unlocks the cursor and stops listening for mouse input
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        InputManager.onMouseDelta -= SetDirection;
    }
}
