using UnityEngine;
using UnityEngine.UI;

public class FishSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int requiredFish = 5;
    [SerializeField] private GameObject beacon;

    private int totalFish = 0;

    private void Start()
    {
        slider.maxValue = requiredFish;
        slider.value = 0;

        if (beacon != null)
            beacon.SetActive(false);
    }

    private void OnEnable()
    {
        Collectable.collect += OnCollect;
    }

    private void OnDisable()
    {
        Collectable.collect -= OnCollect;
    }

    private void OnCollect(int amount, bool isPoison)
    {
        if (!isPoison) // fish are safe
        {
            totalFish += amount;
            slider.value = totalFish;

            if (totalFish >= requiredFish)
                beacon.SetActive(true);
        }
    }
}
