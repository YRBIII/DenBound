using UnityEngine;
using UnityEngine.UI;

// Tracks collected fish and updates the progress slider and beacon
public class FishSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int requiredFish = 5;
    [SerializeField] private GameObject beacon;

    private int totalFish = 0;

    // Initializes the slider and hides the beacon at the start
    private void Start()
    {
        slider.maxValue = requiredFish;
        slider.value = 0;

        if (beacon != null)
            beacon.SetActive(false);
    }

    // Subscribes to the collect event when enabled
    private void OnEnable()
    {
        Collectable.collect += OnCollect;
    }

    // Unsubscribes from the collect event when disabled
    private void OnDisable()
    {
        Collectable.collect -= OnCollect;
    }

    // Updates fish count and slider when fish are collected
    private void OnCollect(int amount, bool isPoison)
    {
        if (!isPoison) // Fish are always safe to collect
        {
            totalFish += amount;
            slider.value = totalFish;

            if (totalFish >= requiredFish)
                beacon.SetActive(true);
        }
    }
}
