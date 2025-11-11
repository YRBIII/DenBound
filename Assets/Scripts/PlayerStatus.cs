using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : ObjectStatus
{
    [Header("Player UI & Sounds")]
    [SerializeField] private Slider playerHealthSlider; // Slider to display player's health in UI
    [SerializeField] private AudioClip jumpSound;       // Sound to play when the player jumps

    private void OnEnable()
    {
        InputManager.OnJump += HandleJump; // Connects to jump input events
    }

    private void OnDisable()
    {
        InputManager.OnJump -= HandleJump; // Stops using when disabled to avoid errors
    }

    private void HandleJump(float value)
    {
        if (value > 0f) // Detect start of jump input
        {
            PlayJumpSound(); // Play jump sound
        }
    }

    private void Start()
    {
        if (playerHealthSlider != null)
            playerHealthSlider.value = health; // Health slider to match starting health
    }

    public new void Damage(float damage, IDamageable.DamageType type)
    {
        base.Damage(damage, type); // Call base damage logic from ObjectStatus

        if (playerHealthSlider != null)
            playerHealthSlider.value = health; // Update UI to match current health
    }

    private void OnBerryCollected(int amount, bool isPoison)
    {
        if (isPoison)
        {
            // Poisoned berries reduce player's health
            Damage(20f, IDamageable.DamageType.Poison);
        }
        else
        {
            // Non-poison berries could myabe heal the player or just be counted
        }
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null)
            AudioManager.instance.PlaySound(jumpSound, 0.8f); // Play jump sound via AudioManager
    }
}
