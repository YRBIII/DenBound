using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static Action<int, bool> collect; // amount, isPoison
    [SerializeField] private string itemType = "Berry";
    [SerializeField] private bool isPoison = false;
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Collected: {itemType} (Poison? {isPoison})");

            collect?.Invoke(1, isPoison); // tell observers

            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            gameObject.SetActive(false);
        }
    }
}
