using UnityEngine;

// Handles the fish jumping out of the water and being collected or returned
public class FishJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float forwardForce = 3f;

    private Rigidbody rb;
    private bool collectedOrReturned = false;

    // Applies an initial jump force when the fish spawns
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * jumpForce + transform.forward * forwardForce, ForceMode.Impulse);
    }

    // Detects when the fish is caught by the player or falls back into the water
    private void OnTriggerEnter(Collider other)
    {
        // Prevents the fish from being processed more than once
        if (collectedOrReturned) return;

        // Player collects the fish
        if (other.CompareTag("Player"))
        {
            collectedOrReturned = true;

            Collectable.collect?.Invoke(1, false);
            FishSpawnerManager.instance.FishReturnedToWater();

            Destroy(gameObject);
            return;
        }

        // Fish falls back into the water
        if (other.CompareTag("Water"))
        {
            collectedOrReturned = true;

            FishSpawnerManager.instance.FishReturnedToWater();
            Destroy(gameObject);
        }
    }
}
