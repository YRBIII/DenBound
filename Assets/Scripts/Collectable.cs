using System;
using UnityEngine;

// Handles collectible items and notifies other systems when collected
public class Collectable : MonoBehaviour
{
    public static Action<int, bool> collect; // amount collected, whether the item is poisonous
    [SerializeField] private string itemType = "Berry";
    [SerializeField] private bool isPoison = false;
    [SerializeField] private AudioClip collectSound;

    // Detects when the player picks up the collectible
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Collected: {itemType} (Poison? {isPoison})");

            // Notifies listeners that an item was collected
            collect?.Invoke(1, isPoison);

            // Plays a sound effect at the collectible's position
            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Destroy(gameObject);
        }
    }
}
