using UnityEngine;
using UnityEngine.UI;

public class FoodSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int requiredFood = 5;   //  amount needed
    [SerializeField] private GameObject beacon;       //  assign in Inspector

    private int totalFood = 0;

    private void Start()
    {
        slider.maxValue = requiredFood;   //  sets slider target
        slider.value = 0;

        if (beacon != null)
            beacon.SetActive(false);      //  hide beacon until ready
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
        if (!isPoison)
        {
            totalFood += amount;
            slider.value = totalFood;

            if (totalFood >= requiredFood)
                ActivateBeacon();
        }
    }

    private void ActivateBeacon()
    {
        if (beacon != null)
            beacon.SetActive(true);

        Debug.Log("Beacon activated! Player can enter the portal.");
    }
}