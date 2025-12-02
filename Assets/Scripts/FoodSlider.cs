using UnityEngine;
using UnityEngine.UI;

public class FoodSlider : MonoBehaviour
{
    [SerializeField] private Slider slider; // Assign your Slider in Inspector
    private int totalFood = 0;

    private void OnEnable()
    {
        Collectable.collect += OnCollect; // Subscribe to Collectable event
    }

    private void OnDisable()
    {
        Collectable.collect -= OnCollect; // Unsubscribe
    }

    private void OnCollect(int amount, bool isPoison)
    {
        if (!isPoison) // Only count safe berries
        {
            totalFood += amount;
            slider.value = totalFood; // Updates the slider instantly
            // Optional: animate fill instead of instant change
        }
    }
}
