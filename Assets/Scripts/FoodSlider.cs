using UnityEngine;
using UnityEngine.UI;

// Tracks collected food and updates the UI slider accordingly
public class FoodSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int requiredFood = 5;   // Amount needed to complete the goal
    [SerializeField] private GameObject beacon;      // Beacon that activates when enough food is collected

    private int totalFood = 0;

    // Sets up the slider and hides the beacon at the start
    private void Start()
    {
        slider.maxValue = requiredFood;
        slider.value = 0;

        if (beacon != null)
            beacon.SetActive(false);
    }

    // Subscribes to collectible events
    private void OnEnable()
    {
        Collectable.collect += OnCollect;
    }

    // Unsubscribes from collectible events
    private void OnDisable()
    {
        Collectable.collect -= OnCollect;
    }

    // Updates food count and slider when food is collected
    private void OnCollect(int amount, bool isPoison)
    {
        if (!isPoison)
        {
            totalFood += amount;
            slider.value = totalFood;

            if (totalFood >= requiredFood)
                ActivateBeacon();
        }
    }

    // Activates the beacon once the required food amount is reached
    private void ActivateBeacon()
    {
        if (beacon != null)
            beacon.SetActive(true);

        Debug.Log("Beacon activated! Player can enter the portal.");
    }
}
