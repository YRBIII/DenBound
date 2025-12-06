using UnityEngine;

public class FishJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float forwardForce = 3f;

    private Rigidbody rb;
    private bool collectedOrReturned = false; // NEW unified guard flag

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.up * jumpForce + transform.forward * forwardForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Prevent ANY duplicate processing
        if (collectedOrReturned) return;

        // PLAYER CATCHES FISH
        if (other.CompareTag("Player"))
        {
            collectedOrReturned = true;

            Collectable.collect?.Invoke(1, false);
            FishSpawnerManager.instance.FishReturnedToWater();

            Destroy(gameObject);
            return;
        }

        // FISH FALLS INTO WATER
        if (other.CompareTag("Water"))
        {
            collectedOrReturned = true;

            FishSpawnerManager.instance.FishReturnedToWater();
            Destroy(gameObject);
        }
    }
}
