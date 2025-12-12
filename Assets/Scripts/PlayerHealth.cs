using UnityEngine;
using UnityEngine.UI;

// Tracks the player's health and updates the health UI slider
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    // Subscribes to collectible events when the player is active
    private void OnEnable()
    {
        Collectable.collect += OnBerryCollected;
    }

    // Unsubscribes from collectible events when the player is disabled
    private void OnDisable()
    {
        Collectable.collect -= OnBerryCollected;
    }

    // Initializes the player's health at the start of the game
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateSlider();
    }

    // Applies poison damage when a poisonous berry is collected
    private void OnBerryCollected(int amount, bool isPoison)
    {
        if (isPoison)
        {
            TakeDamage(20f);
        }
    }

    // Reduces health and clamps it within a valid range
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateSlider();
    }

    // Updates the health slider UI based on current health
    private void UpdateSlider()
    {
        if (healthSlider != null)
            healthSlider.value = currentHealth / maxHealth;
    }
}
