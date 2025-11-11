using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableObserver : MonoBehaviour
{
    public static CollectableObserver instance; 

    [SerializeField] private TextMeshProUGUI progressText; 
    [SerializeField] private Slider foodSlider;            
    private int totalCollected = 0;                         

    [SerializeField] private int maxFood = 10;            

    private void Awake()
    {
        if (instance == null) instance = this; 
        else Destroy(gameObject);
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
        if (isPoison) return; // Ignore poisoned berries

        totalCollected += amount; // Increment collected count

        if (progressText != null)
            progressText.text = $"Berries: {totalCollected}"; // Update UI text

        if (foodSlider != null)
        {
            foodSlider.maxValue = maxFood;  // Make sure slider's max value is set
            foodSlider.value = totalCollected; // Update slider
        }

        // Optional: Save collected count so progress persists
        SaveManager.clicks = totalCollected;
        SaveManager.instance.Save();
    }
}
