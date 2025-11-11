using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private void OnEnable()
    {
        Collectable.collect += OnBerryCollected;
    }

    private void OnDisable()
    {
        Collectable.collect -= OnBerryCollected;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateSlider();
    }

    private void OnBerryCollected(int amount, bool isPoison)
    {
        if (isPoison)
        {
            TakeDamage(20f); // adjust poison damage
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        if (healthSlider != null)
            healthSlider.value = currentHealth / maxHealth;
    }
}
