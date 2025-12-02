using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float maxY = 30;
    [SerializeField] private float minY = -30;
    [SerializeField] private bool invertY;
    private Vector2 cameraRotation = Vector2.zero;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputManager.onMouseDelta += SetDirection;
    }

    private void SetDirection(Vector2 dir)
    {
        dir.y = invertY ? -dir.y : dir.y;

        cameraRotation.x += dir.x;
        cameraRotation.y += dir.y;
        player.localRotation = Quaternion.Euler(0f, cameraRotation.x, 0f);
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(cameraRotation.y, minY, maxY), 0f, 0f);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        InputManager.onMouseDelta -= SetDirection;
    }
}
