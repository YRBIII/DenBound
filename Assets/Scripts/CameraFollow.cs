using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] [Range(0.1f, 1f)] private float mouseSpeed = 1f;
    [SerializeField] private float maxY = 60;
    [SerializeField] private float minY = -40;
    [SerializeField] private bool invertY;
    private Vector2 _cameraRotation = Vector2.zero;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputManager.onMouseDelta += SetDirection;
    }

    private void SetDirection(Vector2 dir)
    {
        dir.y = invertY ? -dir.y : dir.y;

        _cameraRotation.x += dir.x * mouseSpeed;
        _cameraRotation.y += dir.y * mouseSpeed;
        player.localRotation = Quaternion.Euler(0f, _cameraRotation.x, 0f);
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(_cameraRotation.y, minY, maxY), 0f, 0f);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        InputManager.onMouseDelta -= SetDirection;
    }
}
