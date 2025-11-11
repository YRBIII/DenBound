using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

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

    private void OnAllBerriesCollected()
    {
        if (messageText != null)
            messageText.text = "The bear has gathered enough food. Time to find the river.";

        Debug.Log("All berries collected — Level ready to complete!");
    }
}
