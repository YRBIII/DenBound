using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : ObjectStatus
{
    [Header("Player UI & Sounds")]
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private AudioClip jumpSound;

    private void OnEnable()
    {
        InputManager.OnJump += HandleJump;

        // ORIGINAL collect event (keep this!)
        Collectable.collect += OnBerryCollected;
    }

    private void OnDisable()
    {
        InputManager.OnJump -= HandleJump;

        // Unsubscribe normally
        Collectable.collect -= OnBerryCollected;
    }

    private void Start()
    {
        if (playerHealthSlider != null)
            playerHealthSlider.value = health;
    }

    private void HandleJump(float value)
    {
        if (value > 0f)
            PlayJumpSound();
    }

    public new void Damage(float damage, IDamageable.DamageType type)
    {
        base.Damage(damage, type);

        if (playerHealthSlider != null)
            playerHealthSlider.value = health;
    }

    // MUST match Collectable.collect (int amount, bool isPoison)
    private void OnBerryCollected(int amount, bool isPoison)
    {
        if (isPoison)
        {
            // Poison reduces health
            Damage(20f, IDamageable.DamageType.Poison);
        }
        else
        {
            // Safe berry (no health effect unless you add one)
        }
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null)
            AudioManager.instance.PlaySound(jumpSound, 0.8f);
    }
}
