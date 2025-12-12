using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Manages collectible tracking and updates related UI elements
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Collectible Settings")]
    public int totalBerries = 10;
    private int collectedBerries = 0;

    [Header("UI References")]
    [SerializeField] private Slider foodMeter;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI messageText;

    // Ensures only one GameManager exists in the scene
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Initializes UI elements at the start of the level
    private void Start()
    {
        if (foodMeter != null)
        {
            foodMeter.maxValue = totalBerries;
            foodMeter.value = 0;
        }

        if (messageText != null)
            messageText.text = "";
    }

    // Updates collectible count and UI when an item is collected
    public void AddCollectible(string itemType)
    {
        if (itemType == "Berry")
        {
            collectedBerries++;

            if (foodMeter != null)
                foodMeter.value = collectedBerries;

            if (progressText != null)
                progressText.text = $"{collectedBerries}/{totalBerries} Berries Collected";

            if (collectedBerries >= totalBerries)
                OnAllBerriesCollected();
        }
    }

    // Called when all required collectibles have been gathered
    private void OnAllBerriesCollected()
    {
        if (messageText != null)
            messageText.text = "The bear has gathered enough food.";

        Debug.Log("All food collected — Level ready to complete!");
    }
}
