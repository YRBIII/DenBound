using UnityEngine;
using UnityEngine.UI;

// Manages the player's health, UI updates, and player specific reactions to events
public class PlayerStatus : ObjectStatus
{
    [Header("Player UI & Sounds")]
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private AudioClip jumpSound;

    // Subscribes to input and collectible events when the player is active
    private void OnEnable()
    {
        InputManager.OnJump += HandleJump;
        Collectable.collect += OnBerryCollected;
    }

    // Unsubscribes from events when the player is disabled
    private void OnDisable()
    {
        InputManager.OnJump -= HandleJump;
        Collectable.collect -= OnBerryCollected;
    }

    // Initializes the health UI at the start of the game
    private void Start()
    {
        if (playerHealthSlider != null)
            playerHealthSlider.value = health;
    }

    // Plays a jump sound when the jump input is pressed
    private void HandleJump(float value)
    {
        if (value > 0f)
            PlayJumpSound();
    }

    // Applies damage to the player and updates the health UI
    public new void Damage(float damage, IDamageable.DamageType type)
    {
        base.Damage(damage, type);

        if (playerHealthSlider != null)
            playerHealthSlider.value = health;
    }

    // Responds to berry collection events and applies effects if needed
    private void OnBerryCollected(int amount, bool isPoison)
    {
        if (isPoison)
        {
            Damage(20f, IDamageable.DamageType.Poison);
        }
        else
        {
            // Safe berry collected (no health effect by default)
        }
    }

    // Plays the jump sound effect
    public void PlayJumpSound()
    {
        if (jumpSound != null)
            AudioManager.instance.PlaySound(jumpSound, 0.8f);
    }
}
